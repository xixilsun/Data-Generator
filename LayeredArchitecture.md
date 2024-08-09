The core functionality of your `FrmMain` code revolves around creating and managing a data generation tool within a Windows Forms application. The main tasks performed by this form include loading and setting up a user interface, preparing datasets, handling user interactions, and generating SQL insert queries based on the data prepared. Here’s a breakdown of the core functionalities, along with examples directly from the code:

### 1. **UI Initialization and Event Handling**
   - The `FrmMain_Load` method is responsible for initializing the form when it is loaded. It sets up various event handlers for user interactions, prepares default values, and loads the database list.
   - **Example:**
     ```vb
     AddHandler cboDatabase.SelectedIndexChanged, AddressOf OnDBSelectedIndexChanged
     AddHandler btnGenerate.Click, AddressOf ProcessGenerateData
     AddHandler btnPrepareDataset.Click, AddressOf PrepareDataset
     ```

### 2. **Dataset Preparation**
   - The `PrepareDataset` method handles the preparation of the dataset based on the selected database and table. It retrieves column information and sets default values for categories and subcategories.
   - **Example:**
     ```vb
     Dim Sql = "SELECT COLUMN_NAME AS ColumnName, ... FROM INFORMATION_SCHEMA.COLUMNS C ... WHERE TABLE_NAME = " & SqlStr(SelectedTable)
     Dim Dt As DataTable = GetDataTable(Sql, GetConnectionString(SelectedDatabase))
     dtDataSet.Rows.Clear()

     For Each row In Dt.Rows
         'Set default category & subcategory
         Dim DefaultCategory As String = ""
         Dim DefaultSubcategory As String = ""
         ' ... Additional logic ...
         dtDataSet.Rows.Add(dr)
     Next
     ```

### 3. **SQL Insert Query Generation**
   - The `ProcessGenerateData` method is responsible for generating the SQL insert queries based on the prepared dataset. It iterates over the dataset and constructs the SQL statements to be inserted into the database.
   - **Example:**
     ```vb
     For Each row In dtDataSet.Rows
         dtOutput.Columns.Add(row!ColumnName, System.Type.GetType("System.String"))
         col.Add(row!ColumnName)
     Next

     For i As Integer = 0 To numQty.Value - 1
         Dim ParamList As New List(Of String)
         For Each Row In dtDataSet.Rows
             Dim RandomResult As String = GenerateFakeData(...)
             ParamList.Add(RandomResult)
         Next
         dtOutput.Rows.Add(ParamList.ToArray)
     Next
     ```

### 4. **Validation**
   - The `ValidateGenerate` and `ValidateRow` methods ensure that the data being generated is valid according to predefined rules. They check for empty fields, mismatched categories, and other potential errors before data generation.
   - **Example:**
     ```vb
     Private Function ValidateRow(rowHandle As Integer) As Boolean
         Dim View As GridView = gv
         View.FocusedRowHandle = rowHandle
         Dim ColumnName As String = If(View.GetRowCellValue(rowHandle, "ColumnName")?.ToString, String.Empty)
         ' ... Additional validation logic ...
         If String.IsNullOrWhiteSpace(ColumnName) Then
             MsgBox("ColumnName must not be empty.", MsgBoxStyle.Critical)
             View.SetColumnError(View.Columns("ColumnName"), "ColumnName must not be empty.", DXErrorProvider.ErrorType.Critical)
             Return False
         End If
     End Function
     ```

### 5. **Data Handling and GridView Customization**
   - The code includes methods like `OnParameterChanged`, `OnGridViewCustomRowCellEditForEditing`, and `Gv_RowCellStyle` to handle user interactions with the GridView, such as updating the appearance based on data values and customizing how cells are edited.
   - **Example:**
     ```vb
     Private Sub Gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
         Dim view As GridView = CType(sender, GridView)
         If e.Column.FieldName = "Setting" Then
             Dim ParameterValue As Object = view.GetRowCellValue(e.RowHandle, "Parameter")
             ' ... Additional logic ...
             e.Appearance.BackColor = Color.LightYellow
         End If
     End Sub
     ```

This code primarily focuses on allowing users to prepare datasets, generate corresponding SQL queries, and customize their data generation process through a dynamic and responsive UI.


For `FrmMain.vb`, you can define the layers as follows:

### 1. **Presentation Layer (UI Layer)**
   - **Responsibility**: Handles all the user interactions, such as button clicks, form loading, and displaying data to the user.
   - **Code Example**:
     - **Event Handling**: Code that handles events triggered by user actions, such as button clicks or selecting items in a dropdown.
     ```vb
     Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         ' Initializes the form and its controls.
         cboDatabase.SelectedIndex = 0
         LoadDatabaseList()
     End Sub

     Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
         ' Trigger the data generation process.
         ProcessGenerateData()
     End Sub
     ```
   - **GridView Customization**: Any code that customizes the appearance of the GridView based on user inputs.
     ```vb
     Private Sub Gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
         Dim view As GridView = CType(sender, GridView)
         If e.Column.FieldName = "Setting" Then
             Dim ParameterValue As Object = view.GetRowCellValue(e.RowHandle, "Parameter")
             If ParameterValue.ToString.Contains("Special") Then
                 e.Appearance.BackColor = Color.LightYellow
             End If
         End If
     End Sub
     ```

### 2. **Business Logic Layer (BLL)**
   - **Responsibility**: Contains the core business logic, including data validation, dataset preparation, and SQL query generation.
   - **Code Example**:
     - **Dataset Preparation**: Code that prepares datasets based on user inputs, but not directly interacting with the UI controls.
     ```vb
     Public Function PrepareDataset(ByVal selectedDatabase As String, ByVal selectedTable As String) As DataTable
         ' Prepare the dataset with column names and default values.
         Dim Sql As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = " & SqlStr(selectedTable)
         Return GetDataTable(Sql, GetConnectionString(selectedDatabase))
     End Function
     ```
     - **SQL Generation**: Logic that constructs SQL statements based on the dataset, without interacting with UI controls.
     ```vb
     Public Function GenerateSQLInsert(ByVal dtDataSet As DataTable, ByVal numQty As Integer) As List(Of String)
         Dim sqlStatements As New List(Of String)
         For i As Integer = 0 To numQty - 1
             Dim ParamList As New List(Of String)
             For Each Row In dtDataSet.Rows
                 Dim RandomResult As String = GenerateFakeData(...)
                 ParamList.Add(RandomResult)
             Next
             sqlStatements.Add("INSERT INTO " & SelectedTable & " VALUES (" & String.Join(", ", ParamList) & ")")
         Next
         Return sqlStatements
     End Function
     ```

### 3. **Data Access Layer (DAL)**
   - **Responsibility**: Manages data access, including retrieving data from the database and executing SQL queries.
   - **Code Example**:
     - **Database Connection and Data Retrieval**: Code that interacts with the database to execute queries and return results.
     ```vb
     Public Function GetDataTable(ByVal Sql As String, ByVal connectionString As String) As DataTable
         Using connection As New SqlConnection(connectionString)
             Dim adapter As New SqlDataAdapter(Sql, connection)
             Dim dt As New DataTable
             adapter.Fill(dt)
             Return dt
         End Using
     End Function

     Public Sub ExecuteSQL(ByVal sql As String, ByVal connectionString As String)
         Using connection As New SqlConnection(connectionString)
             connection.Open()
             Dim command As New SqlCommand(sql, connection)
             command.ExecuteNonQuery()
         End Using
     End Sub
     ```

### How to Refactor Code into These Layers:

- **Move the `FrmMain_Load`, `btnGenerate_Click`, and other UI-specific methods to the Presentation Layer**.
- **Move the data preparation logic (like `PrepareDataset`) and SQL generation (like `GenerateSQLInsert`) to the Business Logic Layer**.
- **Move the methods dealing with database access, like `GetDataTable` and `ExecuteSQL`, to the Data Access Layer**.

### Benefits of Layered Architecture:

- **Separation of Concerns**: Each layer is focused on a specific aspect of the application, making the code easier to maintain and modify.
- **Reusability**: Business logic and data access can be reused across different parts of the application or even different projects.
- **Testability**: Each layer can be tested independently, ensuring more robust and reliable code.

This restructuring will help in making your application more modular and easier to manage.


