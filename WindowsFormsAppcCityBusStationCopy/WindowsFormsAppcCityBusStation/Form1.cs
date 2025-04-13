using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppcCityBusStation.Models;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Data.Common;
using System.IO;

namespace WindowsFormsAppcCityBusStation
{
    public partial class Form1 : Form
    {
        private dynamic currentEntity;
        private Type currentEntityType;
        private int currentEntityId;
        private bool roleFlag;
        private readonly Dictionary<string, string> _navigationMappings = new Dictionary<string, string>
        {
            { "Carrier", "Carriers" },
            { "PlaceOfDeparture", "Destinations" },
            { "PlaceOfArrival", "Destinations" },
            { "Driver", "Drivers" },
            { "Bus", "Buses" },
            { "Route", "Routes" },
            { "Schedule", "Schedules" }
        };

        List<string> _nameID = new List<string>() { "IDBus", "IDCarrier", "IDDestination", "IDDriver", "IDRoute", "IDSchedule", "IDTicket" };

        public Form1()
        {
            InitializeComponent();
            buttonToMain.Click += ShowPanelMain_Click;
            buttonFromSignInToMain.Click += buttonFromSignInToMain_Click;
            dataGridViewData.CellContentClick += TableButton_Click;
            buttonFromEditToMain.Click += ShowPanelMain_Click;
            splitContainerEdit.Panel2.Resize += splitContainerEdit_Panel2_Resize;
            buttonCreate.Click += buttonFromDataToCreate_Click;
            buttonResultEdit.Click += ButtonResultEdit_Click;
            buttonUpload.Click += buttonUpload_Click;
            buttonFromMainSignIn.Click += ShowPanelSignIn_Click;
        }

        private void ShowPanelData_Click()
        {
            panelData.Visible = true;
            panelMain.Visible = false;
            panelSignIn.Visible = false;
            panelEdit.Visible = false;
        }

        private void ShowPanelMain_Click(object sender, EventArgs e)
        {
            panelMain.Visible = true;
            panelSignIn.Visible = false;
            panelEdit.Visible = false;
            panelData.Visible = false;
        }

        private void ShowPanelSignIn_Click(object sender, EventArgs e)
        {
            panelSignIn.Visible = true;
            panelMain.Visible = false;
            panelData.Visible = false;
            panelEdit.Visible = false;
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        private void ShowPanelEdit_Click()
        {
            panelEdit.Visible = true;
            panelSignIn.Visible = false;
            panelMain.Visible = false;
            panelData.Visible = false;
        }

        private void buttonFromMainToShedules_Click(object sender, EventArgs e)
        {
            LoadSchedulesData();
        }

        private void buttonFromMainToRoutes_Click(object sender, EventArgs e)
        {
            LoadRoutesData();
        }

        private void buttonFromMainToDrivers_Click(object sender, EventArgs e)
        {
            LoadDriversData();
        }

        private void buttonFromMainToPoints_Click(object sender, EventArgs e)
        {
            LoadPointsData();
        }

        private void buttonFromMainToBuses_Click(object sender, EventArgs e)
        {
            LoadBusesData();
        }

        private void buttonFromMainToTickets_Click(object sender, EventArgs e)
        {
            LoadTicketsData();
        }

        private void buttonFromDataToCreate_Click(object sender, EventArgs e)
        {
            var idColumn = dataGridViewData.Columns
          .Cast<DataGridViewColumn>()
          .FirstOrDefault(c => c.Name.StartsWith("ID"));

            var entityType = GetEntityTypeByColumnName(idColumn.Name);
            currentEntityType = entityType;

            dynamic newEntity = Activator.CreateInstance(entityType);

            buttonResultEdit.Visible = true;
            labelEditTitle.Text = "Создать";
            buttonResultEdit.Text = "Создать запись";
            AddDynamicFormForCreate(newEntity);
            ShowPanelEdit_Click();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var idColumn = dataGridViewData.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.Name.StartsWith("ID"));

                if (idColumn == null)
                {
                    MessageBox.Show("Не найден столбец с ID");
                    return;
                }

                var entityType = GetEntityTypeByColumnName(idColumn.Name);
                if (entityType == null)
                {
                    MessageBox.Show("Не удалось определить тип сущности");
                    return;
                }

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt",
                    Title = "Сохранить данные сущности",
                    FileName = $"{entityType.Name}_export_{DateTime.Now:yyyyMMdd}.txt"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                ExportEntityDataToFile(entityType, saveFileDialog.FileName);

                MessageBox.Show($"Данные успешно экспортированы в файл:\n{saveFileDialog.FileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}");
                Console.WriteLine($"Ошибка при экспорте данных: {ex.Message}");
            }
        }

        private void buttonFromSignInToMain_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            using (var context = new CityBusStationEntities())
            {
                try
                {
                    var user = context.Autorization.FirstOrDefault(a => a.Login == login);

                    if (user == null)
                    {
                        MessageBox.Show("Пользователь с таким логином не найден");
                        return;
                    }

                    if (user.Password != password)
                    {
                        MessageBox.Show("Неверный пароль");
                        return;
                    }

                    int userRole = user.Role;
                    var role = context.Roles.Find(userRole);
                    if (role == null)
                    {
                        MessageBox.Show("Такой роли нет!");
                        return;
                    }
                    string roleName = role.Role;
                    if (role == null)
                    {
                        MessageBox.Show("Такой роли нет!");
                        return;
                    }
                    if (roleName == "Admin")
                    {
                        roleFlag = true;
                    }
                    if (roleName == "Cashier")
                    {
                        roleFlag = false;
                    }

                    ShowPanelMain_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка авторизации: {ex.Message}");
                }
            }
        }

        private void ExportEntityDataToFile(Type entityType, string filePath)
        {
            using (var context = new CityBusStationEntities())
            {
                try
                {
                    var setMethod = typeof(DbContext).GetMethods()
                        .FirstOrDefault(m => m.Name == "Set" &&
                                           m.IsGenericMethod &&
                                           m.GetParameters().Length == 0);

                    if (setMethod == null)
                        throw new InvalidOperationException("Не удалось найти метод Set<T>");

                    var genericSetMethod = setMethod.MakeGenericMethod(entityType);
                    dynamic dbSet = genericSetMethod.Invoke(context, null);

                    var data = new List<object>();
                    foreach (var item in dbSet)
                    {
                        data.Add(item);
                    }

                    var properties = entityType.GetProperties()
                        .Where(p => !IsNavigationProperty(p) &&
                                   !IsCollectionProperty(p) &&
                                   (p.PropertyType.IsPrimitive ||
                                    p.PropertyType == typeof(string) ||
                                    p.PropertyType == typeof(DateTime)))
                        .ToList();

                    var sb = new StringBuilder();

                    sb.AppendLine(string.Join("|", properties.Select(p => p.Name)));

                    foreach (var item in data)
                    {
                        var values = properties.Select(p =>
                        {
                            var value = p.GetValue(item);
                            return value != null ? value.ToString() : "NULL";
                        });
                        sb.AppendLine(string.Join("|", values));
                    }

                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка при экспорте данных: {ex.Message}", ex);
                }
            }
        }

        private void LoadSchedulesData()
        {
            labelTitle.Text = "Расписание";

            using (var context = new CityBusStationEntities())
            {
                var schedules = context.Schedules.Select(s => new
                {
                    s.IDSchedule,
                    s.Route,
                    s.DepartureDate,
                    s.Bus,
                    s.Driver
                }).ToList();
                dataGridViewData.DataSource = schedules;
            }
            if (roleFlag)
            {
                AddColumnEditData(dataGridViewData);
                buttonCreate.Visible = true;
            }
            else
            {
                buttonCreate.Visible = false;
                if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
            }
            ShowPanelData_Click();
        }

        private void LoadRoutesData()
        {
            try
            {
                labelTitle.Text = "Маршруты";

                using (var context = new CityBusStationEntities())
                {
                    var routes = context.Routes.Select(r => new
                    {
                        r.IDRoute,
                        r.PlaceOfDeparture,
                        r.PlaceOfArrival,
                        r.TimeOfDeparture,
                        r.TravelTimeInHours
                    }).ToList();
                    dataGridViewData.DataSource = routes;
                }
                if (roleFlag)
                {
                    AddColumnEditData(dataGridViewData);
                    buttonCreate.Visible = true;
                }
                else
                {
                    buttonCreate.Visible = false;
                    if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                    if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                    if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
                }
                ShowPanelData_Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void LoadDriversData()
        {
            labelTitle.Text = "Водители";

            using (var context = new CityBusStationEntities())
            {
                var drivers = context.Drivers.Select(d => new
                {
                    d.IDDriver,
                    d.Surname,
                    d.Name,
                    d.Patronymic,
                    d.Age,
                    d.YearsOfDrivingExperience
                }).ToList();
                dataGridViewData.DataSource = drivers;
            }
            if (roleFlag)
            {
                AddColumnEditData(dataGridViewData);
                buttonCreate.Visible = true;
            }
            else
            {
                buttonCreate.Visible = false;
                if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
            }
            ShowPanelData_Click();
        }

        private void LoadPointsData()
        {
            labelTitle.Text = "Пункты назначения";

            using (var context = new CityBusStationEntities())
            {
                var destinations = context.Destinations.Select(d => new
                {
                    d.IDDestination,
                    d.City,
                    d.Street,
                    d.House
                }).ToList();

                dataGridViewData.DataSource = destinations;
            }
            if (roleFlag)
            {
                AddColumnEditData(dataGridViewData);
                buttonCreate.Visible = true;
            }
            else
            {
                buttonCreate.Visible = false;
                if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
            }
            ShowPanelData_Click();
        }

        private void LoadBusesData()
        {
            labelTitle.Text = "Автобусы";

            using (var context = new CityBusStationEntities())
            {
                var buses = context.Buses.Select(b => new
                {
                    b.IDBus,
                    b.Carrier,
                    b.BusNumber,
                    b.NumberOfSeats,
                    b.FireExtinguisher
                }).ToList();
                dataGridViewData.DataSource = buses;
            }
            if (roleFlag)
            {
                AddColumnEditData(dataGridViewData);
                buttonCreate.Visible = true;
            }

            else
            {
                buttonCreate.Visible = false;
                if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
            }
            ShowPanelData_Click();
        }

        private void LoadTicketsData()
        {
            labelTitle.Text = "Билеты";
            buttonCreate.Visible = true;
            using (var context = new CityBusStationEntities())
            {
                var tickets = context.Tickets.Select(t => new
                {
                    t.IDTicket,
                    t.Surname,
                    t.Name,
                    t.Patronymic,
                    t.Age,
                    t.PassportSeriesAndNumber,
                    t.Schedule,
                    t.PlaceNumber,
                    t.Pets,
                    t.BoughtOut
                }).ToList();
                dataGridViewData.DataSource = tickets;
            }
            if (!roleFlag)
                AddColumnEditData(dataGridViewData);
            else
            {
                buttonCreate.Visible = false;
                if (dataGridViewData.Columns.Contains("Edit")) dataGridViewData.Columns.Remove("Edit");
                if (dataGridViewData.Columns.Contains("Delete")) dataGridViewData.Columns.Remove("Delete");
                if (dataGridViewData.Columns.Contains("Details")) dataGridViewData.Columns.Remove("Details");
            }
            ShowPanelData_Click();
        }

        private void AddColumnEditData(DataGridView d)
        {
            if (d.Columns.Contains("Edit")) d.Columns.Remove("Edit");
            if (d.Columns.Contains("Delete")) d.Columns.Remove("Delete");
            if (d.Columns.Contains("Details")) d.Columns.Remove("Details");

            var boolColumns = new List<string>();
            foreach (DataGridViewColumn column in d.Columns)
            {
                if (column.ValueType == typeof(bool?) || column.ValueType == typeof(bool))
                {
                    boolColumns.Add(column.Name);
                }
            }

            foreach (var columnName in boolColumns)
            {
                var column = d.Columns[columnName];
                var checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = column.HeaderText,
                    Name = column.Name,
                    DataPropertyName = column.DataPropertyName,
                    Width = column.Width,
                    TrueValue = true,
                    FalseValue = false
                };

                int columnIndex = column.Index;
                d.Columns.Remove(column);
                d.Columns.Insert(columnIndex, checkBoxColumn);
            }

            var editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.HeaderText = "";
            editButton.Text = "Изменить";
            editButton.UseColumnTextForButtonValue = true;
            d.Columns.Add(editButton);

            var detailsButton = new DataGridViewButtonColumn();
            detailsButton.Name = "Details";
            detailsButton.HeaderText = "";
            detailsButton.Text = "Детали";
            detailsButton.UseColumnTextForButtonValue = true;
            d.Columns.Add(detailsButton);

            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "";
            deleteButton.Text = "Удалить";
            deleteButton.UseColumnTextForButtonValue = true;
            d.Columns.Add(deleteButton);

            d.Columns["Edit"].DisplayIndex = d.Columns.Count - 3;
            d.Columns["Details"].DisplayIndex = d.Columns.Count - 2;
            d.Columns["Delete"].DisplayIndex = d.Columns.Count - 1;
        }

        private void TableButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dataGridViewData.Columns[e.ColumnIndex].Name;
            var idColumn = dataGridViewData.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.Name.StartsWith("ID"));

            if (idColumn == null)
            {
                MessageBox.Show("Не найден столбец с ID");
                return;
            }

            var cellValue = dataGridViewData.Rows[e.RowIndex].Cells[idColumn.Index].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int idValue))
            {
                MessageBox.Show("Некорректное значение ID");
                return;
            }

            var entityType = GetEntityTypeByColumnName(idColumn.Name);
            if (entityType == null)
            {
                MessageBox.Show("Неизвестный тип данных");
                return;
            }

            dynamic entity = GetEntityById(entityType, idValue);
            if (entity == null)
            {
                MessageBox.Show("Данные не найдены");
                return;
            }

            switch (columnName)
            {
                case "Edit":
                    SetupEditForm(entity, "Изменить", "Сохранить изменения");
                    break;
                case "Details":
                    SetupDetailsForm(entity);
                    break;
                case "Delete":
                    SetupDeleteForm(entity);
                    break;
            }
        }

        private Type GetEntityTypeByColumnName(string columnName)
        {
            var typeMap = new Dictionary<string, Type>
            {
                { "IDSchedule", typeof(Schedules) },
                { "IDBus", typeof(Buses) },
                { "IDDriver", typeof(Drivers) },
                { "IDDestination", typeof(Destinations) },
                { "IDTicket", typeof(Tickets) },
                { "IDRoute", typeof(Routes) }
            };

            return typeMap.TryGetValue(columnName, out var type) ? type : null;
        }

        private object GetEntityById(Type entityType, int id)
        {
            var method = this.GetType().GetMethod("GetEntityByIdGeneric",
                          BindingFlags.NonPublic | BindingFlags.Instance)
                          .MakeGenericMethod(entityType);
            return method.Invoke(this, new object[] { id });
        }

        private T GetEntityByIdGeneric<T>(int id) where T : class
        {
            using (var context = new CityBusStationEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var entity = context.Set<T>().Find(id);

                if (entity is Schedules schedule)
                {
                    context.Entry(schedule).Reference(s => s.Buses).Load();
                    context.Entry(schedule).Reference(s => s.Drivers).Load();
                    context.Entry(schedule).Reference(s => s.Routes).Load();
                    context.Entry(schedule).Collection(s => s.Tickets).Load();
                }
                return entity;
            }
        }

        private void SetupEditForm(dynamic entity, string title, string buttonText)
        {
            currentEntity = entity;
            currentEntityType = entity.GetType();
            currentEntityId = GetEntityId(entity);

            buttonResultEdit.Visible = true;
            labelEditTitle.Text = title;
            buttonResultEdit.Text = buttonText;
            AddDynamicForm(entity, true);
            DisableIdFields();
            ShowPanelEdit_Click();
        }

        private void SetupDetailsForm(dynamic entity)
        {
            labelEditTitle.Text = "Детали";
            buttonResultEdit.Visible = false;
            AddDynamicForm(entity);
            DisableIdFields();
            ShowPanelEdit_Click();
        }

        private void SetupDeleteForm(dynamic entity)
        {
            currentEntity = entity;
            currentEntityType = entity.GetType();
            currentEntityId = GetEntityId(entity);

            labelEditTitle.Text = "Удалить";
            buttonResultEdit.Visible = true;
            buttonResultEdit.Text = "Удалить";
            AddDynamicForm(entity);
            DisableIdFields();
            ShowPanelEdit_Click();
        }

        private int GetEntityId(dynamic entity)
        {
            var type = (Type)entity.GetType();
            var idProp = type.GetProperties()
                           .FirstOrDefault(p => p.Name.StartsWith("ID"));
            return (int)idProp.GetValue(entity);
        }

        private void AddDynamicForm(dynamic entity, bool readField = false)
        {
            splitContainerEdit.Panel2.Controls.Clear();
            int yPos = 10;
            int panelWidth = splitContainerEdit.Panel2.Width;
            int controlWidth = panelWidth / 2;

            using (var context = new CityBusStationEntities())
            {
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (IsCollectionProperty(prop)) continue;

                    if (IsNavigationProperty(prop)) continue;

                    var lbl = new Label
                    {
                        Text = $"{prop.Name}:",
                        Location = new Point(10, yPos),
                        Width = controlWidth - 20,
                        Height = 30,
                        Font = new Font("Segoe UI", 14)
                    };

                    splitContainerEdit.Panel2.Controls.Add(lbl);

                    object propValue = prop.GetValue(entity);
                    Control inputControl;
                    string navigationPropertyName;

                    if (_navigationMappings.TryGetValue(prop.Name, out navigationPropertyName))
                    {
                        inputControl = CreateNavigationComboBox(context, navigationPropertyName, propValue, controlWidth, yPos, readField);
                    }
                    else
                    {
                        inputControl = CreateSimpleInputControl(prop, propValue, controlWidth, yPos, readField);
                    }

                    if (inputControl != null)
                    {
                        splitContainerEdit.Panel2.Controls.Add(inputControl);
                        yPos += 35;
                    }
                }
            }
        }

        private ComboBox CreateNavigationComboBox(CityBusStationEntities context, string entityTypeName, object currentValue, int xPos, int yPos, bool readField)
        {
            int controlWidth = (int)(splitContainerEdit.Panel2.Width * 0.4);
            int labelWidth = splitContainerEdit.Panel2.Width - controlWidth - 30;

            var combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(labelWidth + 20, yPos),
                Width = controlWidth,
                Height = 50,
                Font = new Font("Segoe UI", 14),
                DropDownHeight = 200,
                Enabled = readField,
                Tag = entityTypeName // Сохраняем тип связанной сущности
            };

            // Загрузка данных
            var entityType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == entityTypeName);

            if (entityType != null)
            {
                var setMethod = typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
                                .MakeGenericMethod(entityType);
                var dbSet = (IQueryable)setMethod.Invoke(context, null);

                var idProperty = entityType.GetProperties()
                    .FirstOrDefault(p => _nameID.Contains(p.Name));
                var displayProperty = entityType.GetProperties()
                    .FirstOrDefault(p => p.Name == "Name" || p.Name == "Surname" || p.Name == "BusNumber");

                var items = new List<ComboBoxItem>();
                foreach (var item in dbSet)
                {
                    items.Add(new ComboBoxItem(
                        (int)idProperty.GetValue(item),
                        displayProperty?.GetValue(item)?.ToString() ?? idProperty.GetValue(item).ToString()
                    ));
                }

                combo.DisplayMember = "DisplayText";
                combo.ValueMember = "Id";
                combo.DataSource = items;

                if (currentValue != null)
                {
                    combo.SelectedValue = Convert.ToInt32(currentValue);
                }
            }

            return combo;
        }

        public class ComboBoxItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }

            public ComboBoxItem(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }
        }

        private Control CreateSimpleInputControl(PropertyInfo prop, object propValue, int xPos, int yPos, bool readField)
        {
            int controlWidth = (int)(splitContainerEdit.Panel2.Width * 0.4);
            int labelWidth = splitContainerEdit.Panel2.Width - controlWidth - 30;

            if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                return new CheckBox
                {
                    Checked = (bool?)propValue ?? false,
                    Location = new Point(labelWidth + 20, yPos),
                    Width = controlWidth,
                    Height = 50,
                    Font = new Font("Segoe UI", 14),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Enabled = readField
                };
            }
            else
            {
                return new TextBox
                {
                    Text = propValue?.ToString() ?? "",
                    Location = new Point(labelWidth + 20, yPos),
                    Width = controlWidth,
                    Height = 50,
                    Multiline = false,
                    Font = new Font("Segoe UI", 14),
                    ReadOnly = !readField
                };
            }
        }

        private void DisableIdFields()
        {
            foreach (Control control in splitContainerEdit.Panel2.Controls)
            {
                if (control is Label label && label.Text.StartsWith("ID"))
                {
                    int index = splitContainerEdit.Panel2.Controls.IndexOf(label);
                    if (index < splitContainerEdit.Panel2.Controls.Count - 1)
                    {
                        var nextControl = splitContainerEdit.Panel2.Controls[index + 1];
                        if (nextControl is TextBoxBase)
                        {
                            nextControl.Enabled = false;
                        }
                    }
                }
            }
        }

        private bool IsCollectionProperty(PropertyInfo prop)
        {
            return prop.PropertyType.IsGenericType &&
                   (prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        private void splitContainerEdit_Panel2_Resize(object sender, EventArgs e)
        {
            int controlHeight = 50;
            foreach (Control control in splitContainerEdit.Panel2.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.Width = splitContainerEdit.Panel2.Width / 2 - 20;
                    var padding = (controlHeight - txt.PreferredHeight) / 2;
                    if (padding > 0)
                    {
                        txt.Margin = new Padding(0, padding, 0, 0);
                    }
                }
                else if (control is Label lbl)
                {
                    lbl.Width = splitContainerEdit.Panel2.Width / 2 - 20;
                }
            }
        }

        private bool IsNavigationProperty(PropertyInfo prop)
        {
            if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                return false;

            return prop.PropertyType.Namespace == "WindowsFormsAppcCityBusStation.Models" ||
                   prop.PropertyType.Namespace?.StartsWith("System.Collections.Generic") == true;
        }

        private void ButtonResultEdit_Click(object sender, EventArgs e)
        {
            if (buttonResultEdit.Text == "Сохранить изменения")
            {
                SaveChanges();
            }
            else if (buttonResultEdit.Text == "Удалить")
            {
                DeleteEntity();
            }
            else if (buttonResultEdit.Text == "Создать запись")
            {
                CreateEntity();
            }

            RefreshDataGridView();
        }

        private void SaveChanges()
        {
            using (var context = new CityBusStationEntities())
            {
                try
                {
                    var entity = context.Set(currentEntityType).Find(currentEntityId);
                    if (entity == null)
                    {
                        MessageBox.Show("Запись не найдена в базе данных");
                        return;
                    }

                    int panelWidth = splitContainerEdit.Panel2.Width;
                    int controlWidth = panelWidth / 2;

                    foreach (Control control in splitContainerEdit.Panel2.Controls)
                    {
                        if (control is Label label)
                        {
                            try
                            {
                                var propName = label.Text.Trim(':');
                                var prop = currentEntityType.GetProperty(propName);
                                if (prop == null) continue;

                                var inputControl = splitContainerEdit.Panel2.Controls
                                    .Cast<Control>()
                                    .FirstOrDefault(c => c.Location.X > controlWidth &&
                                                       c.Location.Y == label.Location.Y);

                                if (inputControl == null) continue;

                                if (inputControl is TextBox textBox)
                                {
                                    if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(entity, textBox.Text);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            var value = Convert.ChangeType(textBox.Text, prop.PropertyType);
                                            prop.SetValue(entity, value);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                else if (inputControl is CheckBox checkBox)
                                {
                                    prop.SetValue(entity, checkBox.Checked);
                                }
                                else if (inputControl is ComboBox comboBox && comboBox.SelectedValue != null)
                                {
                                    var navProp = entity.GetType().GetProperty(propName);
                                    if (navProp != null)
                                    {
                                        var navEntityType = navProp.PropertyType;
                                        var setMethod = typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
                                                            .MakeGenericMethod(navEntityType);
                                        dynamic dbSet = setMethod.Invoke(context, null);

                                        var navEntity = dbSet.Find(comboBox.SelectedValue);
                                        if (navEntity != null)
                                        {
                                            navProp.SetValue(entity, navEntity);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Ошибка при сохранении свойства {label.Text}: {ex.Message}");
                            }
                        }
                    }

                    context.SaveChanges();
                    MessageBox.Show("Изменения сохранены успешно!");

                    RefreshComboBoxData();

                    RefreshDataGridView();
                }
                catch (DbUpdateException dbEx)
                {
                    MessageBox.Show($"Ошибка базы данных при сохранении: {dbEx.InnerException?.Message ?? dbEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                }
            }
        }

        private void RefreshComboBoxData()
        {
            foreach (Control control in splitContainerEdit.Panel2.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    var label = splitContainerEdit.Panel2.Controls
                        .OfType<Label>()
                        .FirstOrDefault(l => l.Location.Y == comboBox.Location.Y);

                    if (label != null)
                    {
                        string propName = label.Text.Trim(':');
                        if (_navigationMappings.TryGetValue(propName, out string entityTypeName))
                        {
                            var currentValue = comboBox.SelectedValue;
                            var newComboBox = CreateNavigationComboBox(
                                new CityBusStationEntities(),
                                entityTypeName,
                                currentValue,
                                comboBox.Location.X,
                                comboBox.Location.Y,
                                comboBox.Enabled);

                            splitContainerEdit.Panel2.Controls.Remove(comboBox);
                            splitContainerEdit.Panel2.Controls.Add(newComboBox);
                        }
                    }
                }
            }
        }

        private void DeleteEntity()
        {
            using (var context = new CityBusStationEntities())
            {
                try
                {
                    var entity = context.Set(currentEntityType).Find(currentEntityId);
                    if (entity != null)
                    {
                        context.Set(currentEntityType).Remove(entity);
                        context.SaveChanges();
                        MessageBox.Show("Запись удалена успешно!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void CreateEntity()
        {
            using (var context = new CityBusStationEntities())
            {
                try
                {
                    dynamic newEntity = Activator.CreateInstance(currentEntityType);
                    context.Set(currentEntityType).Add(newEntity);

                    FillEntityFromControlsForCreate(context, newEntity);

                    context.SaveChanges();
                    MessageBox.Show("Запись успешно создана!");
                    RefreshDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании: {ex.Message}");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddDynamicFormForCreate(dynamic entity)
        {
            splitContainerEdit.Panel2.Controls.Clear();
            int yPos = 10;
            int panelWidth = splitContainerEdit.Panel2.Width;
            int controlWidth = panelWidth / 2;

            using (var context = new CityBusStationEntities())
            {
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name.StartsWith("ID") ||
                        IsCollectionProperty(prop) ||
                        IsNavigationProperty(prop))
                        continue;

                    var lbl = new Label
                    {
                        Text = $"{prop.Name}:",
                        Location = new Point(10, yPos),
                        Width = controlWidth - 20,
                        Height = 30,
                        Font = new Font("Segoe UI", 14)
                    };

                    splitContainerEdit.Panel2.Controls.Add(lbl);

                    object propValue = prop.GetValue(entity);
                    Control inputControl;
                    string navigationPropertyName;

                    if (propValue == null)
                    {
                        if (prop.PropertyType == typeof(string))
                            propValue = string.Empty;
                        else if (prop.PropertyType == typeof(int))
                            propValue = 0;
                        else if (prop.PropertyType == typeof(bool))
                            propValue = false;
                        else if (prop.PropertyType == typeof(DateTime))
                            propValue = DateTime.Now;
                    }

                    if (_navigationMappings.TryGetValue(prop.Name, out navigationPropertyName))
                    {
                        inputControl = CreateNavigationComboBox(
                            context,
                            navigationPropertyName,
                            propValue,
                            controlWidth,
                            yPos,
                            true);
                    }
                    else
                    {
                        inputControl = CreateSimpleInputControl(
                            prop,
                            propValue,
                            controlWidth,
                            yPos,
                            true);
                    }

                    if (inputControl != null)
                    {
                        splitContainerEdit.Panel2.Controls.Add(inputControl);
                        yPos += 35;
                    }
                }
            }
        }

        private void FillEntityFromControlsForCreate(CityBusStationEntities context, dynamic entity)
        {
            int panelWidth = splitContainerEdit.Panel2.Width;
            int controlWidth = panelWidth / 2;

            foreach (Control control in splitContainerEdit.Panel2.Controls)
            {
                if (control is Label label)
                {
                    var propName = label.Text.Trim(':');
                    var prop = currentEntityType.GetProperty(propName);
                    if (prop == null || propName.StartsWith("ID")) continue;

                    var inputControl = splitContainerEdit.Panel2.Controls
                        .Cast<Control>()
                        .FirstOrDefault(c => c.Location.X > controlWidth &&
                                           c.Location.Y == label.Location.Y);

                    if (inputControl == null) continue;

                    if (inputControl is ComboBox comboBox && comboBox.SelectedValue != null)
                    {
                        prop.SetValue(entity, comboBox.SelectedValue);
                    }

                    if (inputControl is TextBox textBox)
                    {
                        SetPropertyFromString(entity, prop, textBox.Text);
                    }
                    else if (inputControl is CheckBox checkBox)
                    {
                        prop.SetValue(entity, checkBox.Checked);
                    }
                    else if (inputControl is NumericUpDown numericUpDown)
                    {
                        prop.SetValue(entity, (int)numericUpDown.Value);
                    }
                    else if (inputControl is DateTimePicker dateTimePicker)
                    {
                        prop.SetValue(entity, dateTimePicker.Value);
                    }
                }
            }
        }

        private void SetPropertyFromString(dynamic entity, PropertyInfo prop, string value)
        {
            if (string.IsNullOrEmpty(value) && prop.PropertyType != typeof(string))
            {
                return;
            }

            try
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(entity, value);
                }
                else if (prop.PropertyType == typeof(int))
                {
                    if (int.TryParse(value, out int intValue))
                        prop.SetValue(entity, intValue);
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    if (DateTime.TryParse(value, out DateTime dateValue))
                        prop.SetValue(entity, dateValue);
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    if (bool.TryParse(value, out bool boolValue))
                        prop.SetValue(entity, boolValue);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка преобразования значения для {prop.Name}: {ex.Message}");
            }
        }

        private void SetNavigationProperty(CityBusStationEntities context, dynamic entity, PropertyInfo prop, object selectedValue)
        {
            var navProp = entity.GetType().GetProperty(prop.Name);
            if (navProp != null)
            {
                var navEntityType = navProp.PropertyType;
                var setMethod = typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
                                    .MakeGenericMethod(navEntityType);
                dynamic dbSet = setMethod.Invoke(context, null);

                var navEntity = dbSet.Find(selectedValue);
                if (navEntity != null)
                {
                    navProp.SetValue(entity, navEntity);
                }
            }
        }

        private void RefreshDataGridView()
        {
            if (currentEntityType.Name.Contains("Tickets"))
            {
                LoadTicketsData();
            }
            else if (currentEntityType.Name.Contains("Schedules"))
            {
                LoadSchedulesData();
            }
            else if (currentEntityType.Name.Contains("Drivers"))
            {
                LoadDriversData();
            }
            else if (currentEntityType.Name.Contains("Buses"))
            {
                LoadBusesData();
            }
            else if (currentEntityType.Name.Contains("Routes"))
            {
                LoadRoutesData();
            }
            else if (currentEntityType.Name.Contains("Destinations"))
            {
                LoadPointsData();
            }
            else
            {
                MessageBox.Show("Неизвестный тип данных для обновления");
                ShowPanelMain_Click(null, null);
            }
        }

        private object GetCurrentEntityFromControls(int panelWidth)
        {
            var controlWidth = panelWidth / 2;
            var entity = Activator.CreateInstance(currentEntityType);

            foreach (Control control in splitContainerEdit.Panel2.Controls)
            {
                if (control is Label label)
                {
                    var propName = label.Text.Trim(':');
                    var prop = currentEntityType.GetProperty(propName);
                    if (prop == null) continue;

                    var inputControl = splitContainerEdit.Panel2.Controls
                        .Cast<Control>()
                        .FirstOrDefault(c => c.Location.X > controlWidth &&
                                           c.Location.Y == label.Location.Y);

                    if (inputControl != null)
                    {
                        if (inputControl is TextBox textBox)
                        {
                            SetPropertyValue(entity, prop, textBox.Text);
                        }
                        else if (inputControl is CheckBox checkBox)
                        {
                            prop.SetValue(entity, checkBox.Checked);
                        }
                        else if (inputControl is ComboBox comboBox)
                        {
                            prop.SetValue(entity, comboBox.SelectedValue);
                        }
                    }
                }
            }

            return entity;
        }

        private void SetPropertyValue(object entity, PropertyInfo prop, string value)
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value);
            }
            else if (prop.PropertyType == typeof(int))
            {
                if (int.TryParse(value, out int intValue))
                    prop.SetValue(entity, intValue);
            }
        }
    }
}

