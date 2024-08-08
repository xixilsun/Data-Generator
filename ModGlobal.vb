Imports System.Data
Imports Bogus
Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports DevExpress.XtraPrinting.Export.Pdf.PdfImageCache
Imports DevExpress.XtraGrid.Views.Layout
Imports System.Text.RegularExpressions
Imports DevExpress.Data.Browsing.Design

Module ModGlobal
    Public GenderList As List(Of String) = New List(Of String) From {"Male", "Female"}
    Private Randomizer = New Random()
    Public Function SqlStr(param As String) As String
        Return "'" & param & "'"
    End Function

    Public Function BogusDatatable() As DataTable
        Dim table As New DataTable

        ' Add columns for Category and Subcategory
        table.Columns.Add("Category", GetType(String))
        table.Columns.Add("Subcategory", GetType(String))
        table.Columns.Add("Description", GetType(String))
        table.Columns.Add("Tag", GetType(String))

        ' Add Address subcategories
        table.Rows.Add("Address", "ZipCode", "Get a zipcode.")
        table.Rows.Add("Address", "City", "Get a city name.", "Popular")
        table.Rows.Add("Address", "StreetAddress", "Get a street address.")
        table.Rows.Add("Address", "CityPrefix", "Get a city prefix.")
        table.Rows.Add("Address", "CitySuffix", "Get a city suffix.")
        table.Rows.Add("Address", "StreetName", "Get a street name.")
        table.Rows.Add("Address", "BuildingNumber", "Get a building number.")
        table.Rows.Add("Address", "StreetSuffix", "Get a street suffix.")
        table.Rows.Add("Address", "SecondaryAddress", "Get a secondary address like 'Apt. 2' or 'Suite 321'.")
        table.Rows.Add("Address", "County", "Get a county.")
        table.Rows.Add("Address", "Country", "Get a country.", "Popular")
        table.Rows.Add("Address", "FullAddress", "Get a full address like Street, City, Country.", "Popular")
        table.Rows.Add("Address", "CountryCode", "Get a random ISO 3166-1 country code.")
        table.Rows.Add("Address", "State", "Get a random state state.")
        table.Rows.Add("Address", "StateAbbr", "Get a state abbreviation.")
        table.Rows.Add("Address", "Latitude", "Get a Latitude.")
        table.Rows.Add("Address", "Longitude", "Get a Longitude.")
        table.Rows.Add("Address", "Direction", "Generates a cardinal or ordinal direction. IE: Northwest, South, SW, E.")
        table.Rows.Add("Address", "CardinalDirection", "Generates a cardinal direction. IE: North, South, E, W.")
        table.Rows.Add("Address", "OrdinalDirection", "Generates an ordinal direction. IE: Northwest, Southeast, SW, NE.")


        ' Add data
        table.Rows.Add("Commerce", "Department", "Get a random commerce department.")
        table.Rows.Add("Commerce", "Price", "Get a random product price.")
        table.Rows.Add("Commerce", "ProductName", "Get a random product name.")
        table.Rows.Add("Commerce", "Categories", "Get random product categories.")
        table.Rows.Add("Commerce", "Ean8", "Get a random EAN-8 barcode number.")
        table.Rows.Add("Commerce", "Ean13", "Get a random EAN-13 barcode number.")
        'table.Rows.Add("Commerce", "Uuid", "Get a random product uuid.")
        table.Rows.Add("Commerce", "Color", "Get a random color.")
        table.Rows.Add("Commerce", "Product", "Get a random product.")
        table.Rows.Add("Commerce", "ProductAdjective", "Get a random product adjective.")
        table.Rows.Add("Commerce", "ProductMaterial", "Get a random product material.")
        table.Rows.Add("Commerce", "ProductDescription", "Get a random product description.")

        table.Rows.Add("Company", "CompanyName", "Get a company name.")
        table.Rows.Add("Company", "CompanySuffix", "Get a company suffix. 'Inc' and 'LLC' etc.")
        table.Rows.Add("Company", "CatchPhrase", "Get a company catch phrase.")
        table.Rows.Add("Company", "Bs", "Get a company BS phrase.")
        'table.Rows.Add("Company", "CatchPhraseAdjective", "")
        'table.Rows.Add("Company", "CatchPhraseDescriptor", "")
        'table.Rows.Add("Company", "CatchPhraseNoun", "")
        'table.Rows.Add("Company", "BsAdjective", "")
        'table.Rows.Add("Company", "BsBuzz", "")
        'table.Rows.Add("Company", "BsNoun", "")


        table.Rows.Add("Database", "Column", "Generates a column name.")
        table.Rows.Add("Database", "Type", "Generates a column type.")
        table.Rows.Add("Database", "Collation", "Generates a collation.")
        table.Rows.Add("Database", "Engine", "Generates a storage engine.")

        table.Rows.Add("Date", "Past", "Get a DateTime in the past between refDate and yearsToGoBack.", "Popular")
        'table.Rows.Add("Date", "PastOffset", "Get a DateTimeOffset in the past between refDate and yearsToGoBack.")
        table.Rows.Add("Date", "Future", "Get a DateTime in the future between refDate and yearsToGoForward.", "Popular")
        'table.Rows.Add("Date", "FutureOffset", "Get a DateTimeOffset in the future between refDate and yearsToGoForward.")
        table.Rows.Add("Date", "Recent", "Get a random DateTime within the last few days.")
        'table.Rows.Add("Date", "RecentOffset", "Get a random DateTimeOffset within the last few days.")
        table.Rows.Add("Date", "Soon", "Get a DateTime that will happen soon.")
        'table'.Rows.Add("Date", "SoonOffset", "Get a DateTimeOffset that will happen soon.")
        table.Rows.Add("Date", "Between", "Get a random DateTime between start and end.", "Popular") 'Must have argument
        table.Rows.Add("Date", "Now", "Get a date using GETDATE().", "Popular")
        'table.Rows.Add("Date", "BetweenOffset", "Get a random DateTimeOffset between start and end.") 'Must have argument
        table.Rows.Add("Date", "Timespan", "Get a random TimeSpan.")
        table.Rows.Add("Date", "Month", "Get a random month.")
        table.Rows.Add("Date", "Weekday", "Get a random weekday.")

        table.Rows.Add("Finance", "Account", "Get an account number. Default length is 8 digits.")
        table.Rows.Add("Finance", "AccountName", "Get an account name. Like 'savings', 'checking', 'Home Loan' etc..")
        table.Rows.Add("Finance", "Amount", "Get a random amount. Default 0 - 1000. Amount will be in thousands.", "Popular")
        table.Rows.Add("Finance", "TransactionType", "Get a transaction type: 'deposit', 'withdrawal', 'payment', or 'invoice'.")
        'table.Rows.Add("Finance", "Currency", "")
        table.Rows.Add("Finance", "CreditCardNumber", "Generate a random credit card number with valid Luhn checksum.")
        table.Rows.Add("Finance", "CreditCardCvv", "Generate a credit card CVV.")
        table.Rows.Add("Finance", "BitcoinAddress", "Generates a random Bitcoin address.")
        table.Rows.Add("Finance", "EthereumAddress", "Generate a random Ethereum address.")
        table.Rows.Add("Finance", "RoutingNumber", "Generates an ABA routing number with valid check digit.")
        table.Rows.Add("Finance", "Iban", "Generates Bank Identifier Code (BIC) code.")
        table.Rows.Add("Finance", "Bic", "Generates an International Bank Account Number (IBAN).")

        table.Rows.Add("Hacker", "Abbreviation", "Returns an abbreviation.")
        table.Rows.Add("Hacker", "Adjective", "Returns a adjective.")
        table.Rows.Add("Hacker", "Noun", "Returns a noun.")
        table.Rows.Add("Hacker", "Verb", "Returns a verb.")
        table.Rows.Add("Hacker", "IngVerb", "Returns a verb ending with -ing.")
        table.Rows.Add("Hacker", "Phrase", "Returns a phrase.")

        table.Rows.Add("Internet", "Avatar", "Generates a legit Internet URL avatar from twitter accounts.")
        table.Rows.Add("Internet", "Email", "Generates an email address.", "Popular")
        table.Rows.Add("Internet", "ExampleEmail", "Generates an example email with @example.com.")
        table.Rows.Add("Internet", "UserName", "Generates user names.")
        table.Rows.Add("Internet", "UserNameUnicode", "Generates a user name preserving Unicode characters.")
        table.Rows.Add("Internet", "DomainName", "Generates a random domain name.")
        table.Rows.Add("Internet", "DomainWord", "Generates a domain word used for domain names.")
        table.Rows.Add("Internet", "DomainSuffix", "Generates a domain name suffix like .com, .net, .org")
        table.Rows.Add("Internet", "Ip", "Gets a random IPv4 address string.")
        table.Rows.Add("Internet", "Port", "Generates a random port number.")
        table.Rows.Add("Internet", "IpAddress", "Gets a random IPv4 IPAddress type.")
        table.Rows.Add("Internet", "IpEndPoint", "Gets a random IPv4 IPEndPoint.")
        table.Rows.Add("Internet", "Ipv6", "Generates a random IPv6 address string.")
        table.Rows.Add("Internet", "Ipv6Address", "Generate a random IPv6 IPAddress type.")
        table.Rows.Add("Internet", "Ipv6EndPoint", "Gets a random IPv6 IPEndPoint.")
        table.Rows.Add("Internet", "UserAgent", "Generates a random user agent.")
        table.Rows.Add("Internet", "Mac", "Gets a random mac address.")
        table.Rows.Add("Internet", "Password", "Generates a random password.")
        table.Rows.Add("Internet", "Color", "Gets a random aesthetically pleasing color near the base RGB.")
        table.Rows.Add("Internet", "Protocol", "Returns a random protocol. HTTP or HTTPS.")
        table.Rows.Add("Internet", "Url", "Generates a random URL.")
        table.Rows.Add("Internet", "UrlWithPath", "Get an absolute URL with random path.")
        table.Rows.Add("Internet", "UrlRootedPath", "Get a rooted URL path like: /foo/bar. Optionally with file extension.")
        'table.Rows.Add("Internet", "Emoji", "")

        table.Rows.Add("Lorem", "Word", "Get a random lorem word.")
        table.Rows.Add("Lorem", "Words", "Get an array of random lorem words.")
        table.Rows.Add("Lorem", "Letter", "Get a character letter.")
        table.Rows.Add("Lorem", "Sentence", "Get a random sentence of specific number of words.")
        table.Rows.Add("Lorem", "Sentences", "Get some sentences.")
        table.Rows.Add("Lorem", "Paragraph", "Get a paragraph.")
        table.Rows.Add("Lorem", "Paragraphs", "Get a specified number of paragraphs.")
        table.Rows.Add("Lorem", "Text", "Get random text on a random lorem methods.", "Popular")
        table.Rows.Add("Lorem", "Lines", "Get lines of lorem.")
        table.Rows.Add("Lorem", "Slug", "Slugify lorem words.")

        table.Rows.Add("Name", "FirstName", "Get a first name. Getting a gender specific name is only supported on locales that support it.")
        table.Rows.Add("Name", "LastName", "Get a last name. Getting a gender specific name is only supported on locales that support it.")
        table.Rows.Add("Name", "FullName", "Get a full name, concatenation of calling FirstName and LastName.", "Popular")
        table.Rows.Add("Name", "Prefix", "Gets a random prefix for a name.")
        table.Rows.Add("Name", "Suffix", "Gets a random suffix for a name.")
        table.Rows.Add("Name", "FindName", "Gets a full name.")
        table.Rows.Add("Name", "JobTitle", "Gets a random job title.")
        table.Rows.Add("Name", "JobDescriptor", "Get a job description.")
        table.Rows.Add("Name", "JobArea", "Get a job area expertise.")
        table.Rows.Add("Name", "JobType", "Get a type of job.")

        table.Rows.Add("Random", "Number", "Get an int from 0 to max.", "Popular")
        table.Rows.Add("Random", "Digits", "Get a random sequence of digits with custom formatting.", "Popular")
        table.Rows.Add("Random", "Decimal", "Get a random decimal, between 0.0 and 1.0.")
        table.Rows.Add("Random", "Double", "Get a random double, between 0.0 and 1.0.")
        table.Rows.Add("Random", "Float", "Get a random float, between 0.0 and 1.0.")
        table.Rows.Add("Random", "Byte", "Generate a random byte between 0 and 255.")
        table.Rows.Add("Random", "SByte", "Generate a random sbyte between -128 and 127.")
        table.Rows.Add("Random", "Char", "Generate a random char between MinValue and MaxValue.")
        table.Rows.Add("Random", "String", "Get a string of characters of a specific length.")
        table.Rows.Add("Random", "Hexadecimal", "Generates a random hexadecimal string.")
        table.Rows.Add("Random", "Bool", "Get a random boolean.", "Popular")
        'table.Rows.Add("Random", "Uuid", "Get a random GUID. Alias for Randomizer.Guid().")
        table.Rows.Add("Random", "Guid", "Get a random GUID.")
        table.Rows.Add("Random", "AlphaNumeric", "Returns a random set of alpha numeric characters 0-9, a-z.")
        table.Rows.Add("Random", "Hash", "Return a random hex hash. Default 40 characters, aka SHA-1.")
        table.Rows.Add("Random", "Replace", "Replaces symbols with numbers and letters. # = number, ? = letter, * = number or letter.")
        table.Rows.Add("Random", "UserDefined", "Get a random value from user defined.")
        table.Rows.Add("Random", "Gender", "Get a random gender.")

        table.Rows.Add("Default", "Null", "Return a NULL value.", "Popular")
        table.Rows.Add("Default", "Empty", "Return an empty string.", "Popular")


        table.Rows.Add("System", "FileName", "Get a random file name.")
        table.Rows.Add("System", "DirectoryPath", "Get a random directory path (Unix).")
        table.Rows.Add("System", "FilePath", "Get a random file path (Unix).")
        table.Rows.Add("System", "CommonFileName", "Generates a random file name with a common file extension.")
        table.Rows.Add("System", "MimeType", "Get a random mime type.")
        table.Rows.Add("System", "CommonFileType", "Returns a commonly used file type.")
        table.Rows.Add("System", "CommonFileExt", "Returns a commonly used file extension.")
        table.Rows.Add("System", "FileType", "Returns any file type available as mime-type.")
        table.Rows.Add("System", "FileExt", "Gets a random extension for the given mime type.")
        table.Rows.Add("System", "Semver", "Get a random semver version string.")
        table.Rows.Add("System", "Version", "Get a random Version.")
        table.Rows.Add("System", "Exception", "Get a random Exception with a fake stack trace.")
        table.Rows.Add("System", "AndroidId", "Get a random GCM registration ID.")
        table.Rows.Add("System", "ApplePushToken", "Get a random Apple Push Token.")
        table.Rows.Add("System", "BlackberryPin", "Get a random BlackBerry Device PIN.")

        table.Rows.Add("Phone", "PhoneNumber", "Get a phone number.", "Popular")
        table.Rows.Add("Phone", "PhoneNumberFormat", "Gets a phone number based on the locale's phone_number.formats[] array index.")

        table.Rows.Add("Rant", "Review", "Generates a random user review.")
        table.Rows.Add("Rant", "Reviews", "Generate an array of random reviews.")

        table.Rows.Add("Vehicle", "Vin", "Generate a vehicle identification number (VIN).")
        table.Rows.Add("Vehicle", "Manufacturer", "Get a vehicle manufacture name. IE: Toyota, Ford, Porsche.")
        table.Rows.Add("Vehicle", "Model", "Get a vehicle model. IE: Camry, Civic, Accord.")
        table.Rows.Add("Vehicle", "Type", "Get a vehicle type. IE: Minivan, SUV, Sedan.")
        table.Rows.Add("Vehicle", "Fuel", "Get a vehicle fuel type. IE: Electric, Gasoline, Diesel.")
        BogusDatatable = table
    End Function
    Public Function GenerateDataFromReference(dtDataset As DataTable, paramList As List(Of String), parentDatabase As String, parentTable As String, parentID As String, query As String, Optional maxLength As Integer = 9999999) As String
        Dim Result As String = ""
        Try
            If parentDatabase <> "" AndAlso parentTable <> "" AndAlso parentID <> "" Then
                Dim Sql = $"SELECT TOP 1 {parentID} FROM {parentTable} ORDER BY NEWID()"
                Result = GetOneData(Sql, "", GetConnectionString(parentDatabase))

                'Check length
                If Result.Length > maxLength Then
                    Dim refLength As Integer = GetOneData($"SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{parentTable}'", 999999, GetConnectionString(parentDatabase))
                    Throw New Exception("Reference result length is more than your column length!" & vbCrLf & "Reference Length : " & refLength)
                End If
            ElseIf query <> "" Then
                'Search previous column data if there is string between pound signs
                Dim Matches As MatchCollection = Regex.Matches(query, "#(.*?)#") 'Match string between pound signs

                For Each match In Matches
                    Dim ColumnSearch = match.Groups(1).Value
                    Dim ColumnIndex = dtDataset.AsEnumerable.Select(Function(row) row!ColumnName.ToString.ToUpper).ToList().IndexOf(ColumnSearch.ToString.ToUpper)
                    If ColumnIndex <> -1 Then
                        query = Regex.Replace(query, "\#(.*?)\#", SqlStr(paramList(ColumnIndex)))
                    Else
                        MsgBox("Unable to find previous data : " & ColumnSearch, MsgBoxStyle.Critical)
                        Return ""
                    End If
                Next

                Dim Dt As DataTable = GetDataTable(query, GetConnectionString(parentDatabase))
                If Dt Is Nothing Then
                    Throw New Exception("Query is invalid!")
                ElseIf Dt.Rows.Count < 1 Then
                    Throw New Exception("No data from reference!")
                End If

                Dim RandomRowIndex As Integer = Randomizer.next(0, Dt.Rows.Count)
                Result = Dt.Rows(RandomRowIndex).Item(0).ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Result
    End Function
    Public Function GenerateFakeData(category As String, subcategory As String, Optional userParameter As String = "", Optional userDefined As String = "", Optional maxLength As Integer = 9999999) As String
        Try
            'Create a new Faker instance
            Dim Fake As New Faker()
            Dim RandomValue As String = ""

            Dim CategoryProperty As PropertyInfo
            Dim CategoryInstance As New Object
            If category <> "Default" Then
                CategoryProperty = GetType(Faker).GetProperty(category, BindingFlags.Public Or BindingFlags.Instance)
                If CategoryProperty Is Nothing Then Throw New Exception("Unknown category")

                CategoryInstance = CategoryProperty.GetValue(Fake)
            End If

            'Special Handling for overloaded methods like Random.Number
            If category = "Random" AndAlso
                ("Number-Bool-String-Gender-UserDefined-Digits-").Contains(subcategory & "-") Then
                If subcategory = "Number" Then
                    Dim max = 1000, min = 0
                    Dim value = GetValueByKey(userParameter, "min", Type.GetType("System.Int32"))
                    If Not IsNothing(value) Then min = value
                    value = GetValueByKey(userParameter, "max", Type.GetType("System.Int32"))
                    If Not IsNothing(value) Then max = value
                    RandomValue = Fake.Random.Number(min, max).ToString()
                ElseIf subcategory = "Bool" Then
                    RandomValue = If(Fake.Random.Bool(), 1, 0)
                ElseIf subcategory = "String" Then
                    Dim length = 10
                    Dim value = GetValueByKey(userParameter, "length", Type.GetType("System.Int32"))
                    If Not IsNothing(value) Then length = value
                    RandomValue = Fake.Random.String(length).ToString
                ElseIf subcategory = "Gender" Then
                    RandomValue = GenderList(Randomizer.Next(0, GenderList.Count))
                ElseIf subcategory = "UserDefined" Then
                    Dim UserDefinedList = userDefined.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
                    RandomValue = UserDefinedList(Randomizer.Next(0, UserDefinedList.Count))
                ElseIf subcategory = "Digits" Then
                    Dim Format As String = "#####"
                    Dim value = GetValueByKey(userParameter, "Format", Type.GetType("System.String"))
                    If Not IsNothing(value) AndAlso value <> "" Then Format = value
                    RandomValue = Fake.Phone.PhoneNumber(Format)
                End If
            ElseIf category = "Company" AndAlso subcategory = "CompanyName" Then
                RandomValue = Fake.Company.CompanyName
            ElseIf category = "Lorem" AndAlso subcategory = "Paragraphs" Then
                RandomValue = Fake.Lorem.Paragraphs()
            ElseIf category = "Date" AndAlso
                    ("Between-Now-".Contains(subcategory & "-")) Then
                Select Case subcategory
                    Case "Now"
                        RandomValue = "GETDATE()"
                    Case "Between"
                        Dim StartDate = Date.Today, EndDate = #2099/01/01#
                        Dim Value = GetValueByKey(userParameter, "start", Type.GetType("System.DateTime"))
                        If Not IsNothing(Value) Then StartDate = Value
                        Value = GetValueByKey(userParameter, "end", Type.GetType("System.DateTime"))
                        If Not IsNothing(Value) Then EndDate = Value
                        RandomValue = Fake.Date.Between(StartDate, EndDate)
                End Select
            ElseIf category = "Default" Then
                If subcategory = "Null" Then
                    RandomValue = "NULL"
                ElseIf subcategory = "Empty" Then
                    RandomValue = ""
                End If
            Else
                Dim SubcategoryMethod As MethodInfo = CategoryInstance.GetType().GetMethod(subcategory, BindingFlags.Public Or BindingFlags.Instance)
                If SubcategoryMethod Is Nothing Then Throw New Exception("Unknown subcategory")

                'Check if the method has parameter
                Dim parameters As ParameterInfo() = SubcategoryMethod.GetParameters()
                Dim result As Object
                If parameters.Length > 0 Then
                    Dim paramValues As Object()
                    If userParameter = "" Then
                        paramValues = parameters.Select(Function(p) GetDefaultValue(p)).ToArray
                    Else
                        paramValues = parameters.Select(Function(o) GetUserParameter(o, userParameter)).ToArray
                    End If
                    result = SubcategoryMethod.Invoke(CategoryInstance, paramValues)
                Else
                    result = SubcategoryMethod.Invoke(CategoryInstance, Nothing)
                End If

                If TypeOf result Is String OrElse TypeOf result Is Double OrElse TypeOf result Is Decimal OrElse TypeOf result Is Char OrElse
                    TypeOf result Is Single OrElse TypeOf result Is Byte OrElse TypeOf result Is DateTime OrElse TypeOf result Is TimeSpan Then
                    If subcategory = "AlphaNumeric" Then
                        Dim IsUpperCase As Boolean = GetValueByKey(userParameter, "IsUpperCase", Type.GetType("System.Boolean"))
                        If IsUpperCase Then result = result.ToString.ToUpper()
                    ElseIf subcategory = "Amount" Then
                        result = result * 1000
                        result = Convert.ToInt32(result)
                    End If
                    RandomValue = Replace(result.ToString, vbLf, vbCrLf)
                Else
                    If result.length > 1 Then
                        For Each obj In result
                            RandomValue &= If(RandomValue = "", "", vbCrLf) & obj.ToString
                        Next
                    End If
                End If
            End If

            'Check length
            If RandomValue IsNot Nothing AndAlso RandomValue.Length > maxLength AndAlso RandomValue <> "NULL" Then
                RandomValue = RandomValue.Substring(0, maxLength)
            End If

            If RandomValue.Contains("'") Then RandomValue = RandomValue.Replace("'", "")
            Return RandomValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return ""
    End Function

    Private Function GetUserParameter(param As ParameterInfo, userParameter As String) As Object
        Dim result As Object = GetValueByKey(userParameter, param.Name, param.ParameterType, param)
        Return result
    End Function

    Public Function ChangeType(ByVal value As Object, ByVal conversion As Type) As Object
        Dim t = conversion

        If t.IsGenericType AndAlso t.GetGenericTypeDefinition().Equals(GetType(Nullable(Of))) Then

            If value Is Nothing Then
                Return Nothing
            End If

            t = Nullable.GetUnderlyingType(t)
        End If

        Return Convert.ChangeType(value, t)
    End Function

    Public Function UppercaseFirstLetter(input As String)
        Dim FirstLetter As String = input.Substring(0, 1).ToUpper()
        Dim RestOfString As String = input.Substring(1)
        Return FirstLetter & RestOfString
    End Function

    Public Function GetValueByKey(userParameter As String, parameterName As String, paramType As Type, Optional param As ParameterInfo = Nothing) As Object
        Dim lines As String() = userParameter.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
        Dim strValue As String = ""
        For Each line In lines
            If line.StartsWith(UppercaseFirstLetter(parameterName) & "=") Then
                strValue = line.Substring((parameterName & "=").Length).Trim
                Exit For
            End If
        Next

        If paramType.ToString.Contains("Gender") Then
            If strValue = "Male" Then
                Return Bogus.DataSets.Name.Gender.Male
            ElseIf strValue = "Female" Then
                Return Bogus.DataSets.Name.Gender.Female
            Else
                strValue = ""
            End If
        End If

        If strValue <> "" Then
            Return ChangeType(strValue, paramType)
        ElseIf param IsNot Nothing Then
            Return GetDefaultValue(param)
        ElseIf paramType <> Type.GetType("System.String") AndAlso strValue = "" Then
            Return Nothing
        Else
            Return strValue
        End If
    End Function

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

    Public Function AreTablesTheSame(ByVal tbl1 As DataTable, ByVal tbl2 As DataTable) As Boolean
        If tbl1.Rows.Count <> tbl2.Rows.Count OrElse tbl1.Columns.Count <> tbl2.Columns.Count Then Return False

        For i As Integer = 0 To tbl1.Rows.Count - 1

            For c As Integer = 0 To tbl1.Columns.Count - 1
                If Not Equals(tbl1.Rows(i)(c), tbl2.Rows(i)(c)) Then Return False
            Next
        Next

        Return True
    End Function
End Module
