Imports System.Data
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Bogus
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Reflection
Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CategoryList As List(Of String) = BogusDatatable().AsEnumerable().Select(Function(o) o("Category").ToString).Distinct().ToList()
        FillComboBox(cboCategory, CategoryList)
        'FillSubcategory(cboCategory.SelectedValue)

        'TestingGenerateData()
        Me.KeyPreview = True
    End Sub
    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnGenerate_Click(sender, e)
        End If
    End Sub
    Private Sub FillSubcategory(category As String)
        Dim SubcategoryList As List(Of String) = BogusDatatable().AsEnumerable().Where(Function(x) x("Category") = category).Select(Function(o) o("Subcategory").ToString).ToList()
        FillComboBox(cboSubcategory, SubcategoryList)
    End Sub

    Private Sub FillComboBox(cboTable As ComboBox, dataSource As List(Of String))
        With cboTable
            .DataSource = dataSource
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub TestingGenerateData()
        Dim faker As New Faker(Of Customer)

        '-- Make a rule for each property
        faker.RuleFor(Function(c) c.FirstName, Function(f) f.Name.FullName) _
             .RuleFor(Function(c) c.LastName, Function(f) f.Name.LastName) _
                                                                           _
             .Rules(Sub(f, c)   '-- Or, alternatively, in bulk with .Rules() 
                        c.Age = f.Random.Int(18, 35)
                        c.Title = f.Name.JobTitle()
                    End Sub)

        Dim cust = faker.Generate(10)
        Dim sb = New StringBuilder()
        For Each cus In cust
            sb.AppendLine(PropertyList(cus))
        Next
        txtQuery.Text = sb.ToString
    End Sub

    Private Sub Test2()
        Dim faker As New Faker("en")
    End Sub
    '<Extension()>
    Public Shared Function PropertyList(ByVal obj As Object) As String
        Dim props = obj.[GetType]().GetProperties()
        Dim sb = New StringBuilder()

        For Each p In props
            sb.AppendLine(p.Name & ": " & p.GetValue(obj, Nothing))
        Next

        Return sb.ToString()
    End Function


    Private Sub cboDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        FillSubcategory(cboCategory.SelectedValue)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOneData.Click
        Try
            Dim faker As New Faker()
            'Dim x = cboCategory.SelectedValue & "." & cboSubcategory.SelectedValue \

            Dim category = cboCategory.SelectedValue
            Dim subcategory = cboSubcategory.SelectedValue

            Dim parsingString = $"{{{{{category}.{subcategory}}}}}"
            'parsingString = "{{name.firstname(Female)}}"
            Dim randomName = faker.Parse(parsingString)
            txtQuery.Text = randomName

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'TestingGenerateData()
    End Sub

    Private Function GenerateFakeData(category As String, subcategory As String)
        Try
            'Create a new Faker instance
            Dim Fake As New Faker()
            Dim RandomValue As String = ""

            Dim CategoryProperty As PropertyInfo = GetType(Faker).GetProperty(category, BindingFlags.Public Or BindingFlags.Instance)
            If CategoryProperty Is Nothing Then Throw New Exception("Unknown category")

            Dim CategoryInstance As Object = CategoryProperty.GetValue(Fake)

            'Special Handling for overloaded methods like Random.Number
            If category = "Random" AndAlso
                (subcategory = "Number" OrElse subcategory = "Bool" OrElse subcategory = "String") Then
                If subcategory = "Number" Then
                    RandomValue = Fake.Random.Number(0, 100).ToString()
                ElseIf subcategory = "Bool" Then
                    RandomValue = Fake.Random.Bool().ToString
                ElseIf subcategory = "String" Then
                    RandomValue = Fake.Random.String(10).ToString
                End If

            ElseIf category = "Company" AndAlso
                    subcategory = "CompanyName" Then
                RandomValue = Fake.Company.CompanyName
            ElseIf category = "Lorem" AndAlso subcategory = "Paragraphs" Then
                RandomValue = Fake.Lorem.Paragraphs(3, vbCrLf)
            Else
                Dim SubcategoryMethod As MethodInfo = CategoryInstance.GetType().GetMethod(subcategory, BindingFlags.Public Or BindingFlags.Instance)
                If SubcategoryMethod Is Nothing Then Throw New Exception("Unknown subcategory")

                'Check if the method has parameter
                Dim parameters As ParameterInfo() = SubcategoryMethod.GetParameters()
                Dim result As Object

                If parameters.Length > 0 Then
                    Dim paramValues As Object() = parameters.Select(Function(p) GetDefaultValue(p)).ToArray
                    result = SubcategoryMethod.Invoke(CategoryInstance, paramValues)
                Else
                    result = SubcategoryMethod.Invoke(CategoryInstance, Nothing)
                End If

                result = Fake.Commerce.Categories(4)
                If TypeOf result Is String Then
                    RandomValue = Replace(result, vbLf, vbCrLf)
                Else
                    If result.length > 1 Then
                        For Each obj In result
                            RandomValue &= If(RandomValue = "", "", vbCrLf) & obj.ToString
                        Next
                    End If
                End If
            End If

            txtQuery.Text = RandomValue
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    'Private Function GetParameterValues(method As MethodInfo) As Object()
    '    Dim parameters As ParameterInfo() = method.GetParameters()
    '    Dim paramValues As Object() = New Object(parameters.Length - 1) {}
    '    For i As Integer = 0 To parameters.Length - 1
    '        Dim paramType As Type = parameters(i).ParameterType
    '    Next
    'End Function

    Private Function GetDefaultValue(param As ParameterInfo) As Object
        If param.HasDefaultValue Then
            Return param.DefaultValue
        ElseIf param.ParameterType.IsValueType Then
            Return Activator.CreateInstance(param.ParameterType)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    'Select Case category
    '    Case "Random"
    '        Select Case subcategory
    '            Case "Number"
    '                result = Fake.Random.Number(0, 100)
    '            Case "Bool"
    '                result = Fake.Random.Bool().ToString
    '            Case "String"
    '                result = Fake.Random.String(10) 'Example length 10
    '            Case Else
    '                Throw New Exception("Unknown Subcategory for Random")
    '        End Select
    '    Case "Date"
    '        Select Case subcategory
    '            Case "Past"
    '                result = Fake.Date.Past().ToString()
    '            Case "Future"
    '                result = Fake.Date.Future().ToString

    '        End Select
    'End Select
    Public Function BogusDatatable() As DataTable
        Dim table As New DataTable

        ' Add columns for Category and Subcategory
        table.Columns.Add("Category", GetType(String))
        table.Columns.Add("Subcategory", GetType(String))

        ' Add Address subcategories
        table.Rows.Add("Address", "ZipCode")
        table.Rows.Add("Address", "City")
        table.Rows.Add("Address", "StreetAddress")
        table.Rows.Add("Address", "CityPrefix")
        table.Rows.Add("Address", "CitySuffix")
        table.Rows.Add("Address", "StreetName")
        table.Rows.Add("Address", "BuildingNumber")
        table.Rows.Add("Address", "StreetSuffix")
        table.Rows.Add("Address", "SecondaryAddress")
        table.Rows.Add("Address", "County")
        table.Rows.Add("Address", "Country")
        table.Rows.Add("Address", "FullAddress")
        table.Rows.Add("Address", "CountryCode")
        table.Rows.Add("Address", "State")
        table.Rows.Add("Address", "StateAbbr")
        table.Rows.Add("Address", "Latitude")
        table.Rows.Add("Address", "Longitude")
        table.Rows.Add("Address", "Direction")
        table.Rows.Add("Address", "CardinalDirection")
        table.Rows.Add("Address", "OrdinalDirection")


        ' Add data
        table.Rows.Add("Commerce", "Department")
        table.Rows.Add("Commerce", "Price")
        table.Rows.Add("Commerce", "ProductName")
        table.Rows.Add("Commerce", "Categories")
        table.Rows.Add("Commerce", "Ean8")
        table.Rows.Add("Commerce", "Ean13")
        table.Rows.Add("Commerce", "Uuid")
        table.Rows.Add("Commerce", "Color")
        table.Rows.Add("Commerce", "Product")
        table.Rows.Add("Commerce", "ProductAdjective")
        table.Rows.Add("Commerce", "ProductMaterial")
        table.Rows.Add("Commerce", "ProductDescription")

        table.Rows.Add("Company", "CompanyName")
        table.Rows.Add("Company", "CompanySuffix")
        table.Rows.Add("Company", "CatchPhrase")
        table.Rows.Add("Company", "Bs")
        'table.Rows.Add("Company", "CatchPhraseAdjective")
        'table.Rows.Add("Company", "CatchPhraseDescriptor")
        'table.Rows.Add("Company", "CatchPhraseNoun")
        'table.Rows.Add("Company", "BsAdjective")
        'table.Rows.Add("Company", "BsBuzz")
        'table.Rows.Add("Company", "BsNoun")


        table.Rows.Add("Database", "Column")
        table.Rows.Add("Database", "Type")
        table.Rows.Add("Database", "Collation")
        table.Rows.Add("Database", "Engine")

        table.Rows.Add("Date", "Past")
        table.Rows.Add("Date", "PastOffset")
        table.Rows.Add("Date", "Future")
        table.Rows.Add("Date", "FutureOffset")
        table.Rows.Add("Date", "Recent")
        table.Rows.Add("Date", "RecentOffset")
        table.Rows.Add("Date", "Soon")
        table.Rows.Add("Date", "SoonOffset")
        table.Rows.Add("Date", "Between") 'Must have argument
        table.Rows.Add("Date", "BetweenOffset") 'Must have argument
        table.Rows.Add("Date", "Timespan")
        table.Rows.Add("Date", "Month")
        table.Rows.Add("Date", "Weekday")

        table.Rows.Add("Finance", "Account")
        table.Rows.Add("Finance", "AccountName")
        table.Rows.Add("Finance", "Amount")
        table.Rows.Add("Finance", "TransactionType")
        'table.Rows.Add("Finance", "Currency")
        table.Rows.Add("Finance", "CreditCardNumber")
        table.Rows.Add("Finance", "CreditCardCvv")
        table.Rows.Add("Finance", "BitcoinAddress")
        table.Rows.Add("Finance", "EthereumAddress")
        table.Rows.Add("Finance", "RoutingNumber")
        table.Rows.Add("Finance", "Iban")
        table.Rows.Add("Finance", "Bic")

        table.Rows.Add("Hacker", "Abbreviation")
        table.Rows.Add("Hacker", "Adjective")
        table.Rows.Add("Hacker", "Noun")
        table.Rows.Add("Hacker", "Verb")
        table.Rows.Add("Hacker", "IngVerb")
        table.Rows.Add("Hacker", "Phrase")

        table.Rows.Add("Internet", "Avatar")
        table.Rows.Add("Internet", "Email")
        table.Rows.Add("Internet", "ExampleEmail")
        table.Rows.Add("Internet", "UserName")
        table.Rows.Add("Internet", "UserNameUnicode")
        table.Rows.Add("Internet", "DomainName")
        table.Rows.Add("Internet", "DomainWord")
        table.Rows.Add("Internet", "DomainSuffix")
        table.Rows.Add("Internet", "Ip")
        table.Rows.Add("Internet", "Port")
        table.Rows.Add("Internet", "IpAddress")
        table.Rows.Add("Internet", "IpEndPoint")
        table.Rows.Add("Internet", "Ipv6")
        table.Rows.Add("Internet", "Ipv6Address")
        table.Rows.Add("Internet", "Ipv6EndPoint")
        table.Rows.Add("Internet", "UserAgent")
        table.Rows.Add("Internet", "Mac")
        table.Rows.Add("Internet", "Password")
        table.Rows.Add("Internet", "Color")
        table.Rows.Add("Internet", "Protocol")
        table.Rows.Add("Internet", "Url")
        table.Rows.Add("Internet", "UrlWithPath")
        table.Rows.Add("Internet", "UrlRootedPath")
        'table.Rows.Add("Internet", "Emoji")

        table.Rows.Add("Lorem", "Word")
        table.Rows.Add("Lorem", "Words")
        table.Rows.Add("Lorem", "Letter")
        table.Rows.Add("Lorem", "Sentence")
        table.Rows.Add("Lorem", "Sentences")
        table.Rows.Add("Lorem", "Paragraph")
        table.Rows.Add("Lorem", "Paragraphs")
        table.Rows.Add("Lorem", "Text")
        table.Rows.Add("Lorem", "Lines")
        table.Rows.Add("Lorem", "Slug")

        table.Rows.Add("Name", "FirstName")
        table.Rows.Add("Name", "LastName")
        table.Rows.Add("Name", "FullName")
        table.Rows.Add("Name", "Prefix")
        table.Rows.Add("Name", "Suffix")
        table.Rows.Add("Name", "FindName")
        table.Rows.Add("Name", "JobTitle")
        table.Rows.Add("Name", "JobDescriptor")
        table.Rows.Add("Name", "JobArea")
        table.Rows.Add("Name", "JobType")

        table.Rows.Add("Random", "Number")
        table.Rows.Add("Random", "Decimal")
        table.Rows.Add("Random", "Double")
        table.Rows.Add("Random", "Float")
        table.Rows.Add("Random", "Byte")
        table.Rows.Add("Random", "SByte")
        table.Rows.Add("Random", "Char")
        table.Rows.Add("Random", "String")
        table.Rows.Add("Random", "Hexadecimal")
        table.Rows.Add("Random", "Bool")
        table.Rows.Add("Random", "Uuid")
        table.Rows.Add("Random", "Guid")
        table.Rows.Add("Random", "AlphaNumeric")
        table.Rows.Add("Random", "Hash")
        table.Rows.Add("Random", "Replace")


        table.Rows.Add("System", "FileName")
        table.Rows.Add("System", "DirectoryPath")
        table.Rows.Add("System", "FilePath")
        table.Rows.Add("System", "CommonFileName")
        table.Rows.Add("System", "MimeType")
        table.Rows.Add("System", "CommonFileType")
        table.Rows.Add("System", "CommonFileExt")
        table.Rows.Add("System", "FileType")
        table.Rows.Add("System", "FileExt")
        table.Rows.Add("System", "Semver")
        table.Rows.Add("System", "Version")
        table.Rows.Add("System", "Exception")
        table.Rows.Add("System", "AndroidId")
        table.Rows.Add("System", "ApplePushToken")
        table.Rows.Add("System", "BlackberryPin")

        table.Rows.Add("Phone", "PhoneNumber")
        table.Rows.Add("Phone", "PhoneNumberFormat")

        table.Rows.Add("Rant", "Review")
        table.Rows.Add("Rant", "Reviews")

        table.Rows.Add("Vehicle", "Vin")
        table.Rows.Add("Vehicle", "Manufacturer")
        table.Rows.Add("Vehicle", "Model")
        table.Rows.Add("Vehicle", "Type")
        table.Rows.Add("Vehicle", "Fuel")
        BogusDatatable = table
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateFakeData(cboCategory.SelectedValue, cboSubcategory.SelectedValue)
    End Sub
End Class


Public Class Customer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Age() As Integer
    Public Property Title() As String
End Class