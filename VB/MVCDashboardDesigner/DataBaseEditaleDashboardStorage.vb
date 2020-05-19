Imports DevExpress.DashboardWeb
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Xml.Linq

Namespace MVCDashboardDesigner
	Public Class DataBaseEditaleDashboardStorage
		Implements IEditableDashboardStorage

		Private connectionString As String

		Public Sub New(ByVal connectionString As String)
			MyBase.New()
			Me.connectionString = connectionString
		End Sub

		Private Function IEditableDashboardStorage_AddDashboard(ByVal document As XDocument, ByVal dashboardName As String) As String Implements IEditableDashboardStorage.AddDashboard
			Using connection As New SqlConnection(connectionString)
				connection.Open()
				Dim stream As New MemoryStream()
				document.Save(stream)
				stream.Position = 0

				Dim InsertCommand As New SqlCommand("INSERT INTO Dashboards (Dashboard, Caption) " & "output INSERTED.ID " & "VALUES (@Dashboard, @Caption)")
				InsertCommand.Parameters.Add("Caption", SqlDbType.NVarChar).Value = dashboardName
				InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray()
				InsertCommand.Connection = connection
				Dim ID As String = InsertCommand.ExecuteScalar().ToString()
				connection.Close()
				Return ID
			End Using
		End Function


		Private Function IDashboardStorage_LoadDashboard(ByVal dashboardID As String) As XDocument Implements IDashboardStorage.LoadDashboard
			Using connection As New SqlConnection(connectionString)
				connection.Open()
				Dim GetCommand As New SqlCommand("SELECT  Dashboard FROM Dashboards WHERE ID=@ID")
				GetCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID)
				GetCommand.Connection = connection
				Dim reader As SqlDataReader = GetCommand.ExecuteReader()
				reader.Read()
				Dim data() As Byte = TryCast(reader.GetValue(0), Byte())
				Dim stream As New MemoryStream(data)
				connection.Close()
				Return XDocument.Load(stream)
			End Using
		End Function

		Private Function IDashboardStorage_GetAvailableDashboardsInfo() As IEnumerable(Of DashboardInfo) Implements IDashboardStorage.GetAvailableDashboardsInfo

			Dim list As New List(Of DashboardInfo)()
			Using connection As New SqlConnection(connectionString)
				connection.Open()
				Dim GetCommand As New SqlCommand("SELECT ID, Caption FROM Dashboards")
				GetCommand.Connection = connection
				Dim reader As SqlDataReader = GetCommand.ExecuteReader()
				Do While reader.Read()
					Dim ID As String = reader.GetInt32(0).ToString()
					Dim Caption As String = reader.GetString(1)
					list.Add(New DashboardInfo() With {.ID = ID, .Name = Caption})
				Loop
				connection.Close()
			End Using
			Return list
		End Function

		Private Sub IDashboardStorage_SaveDashboard(ByVal dashboardID As String, ByVal document As XDocument) Implements IDashboardStorage.SaveDashboard
			Using connection As New SqlConnection(connectionString)
				connection.Open()
				Dim stream As New MemoryStream()
				document.Save(stream)
				stream.Position = 0

				Dim InsertCommand As New SqlCommand("UPDATE Dashboards Set Dashboard = @Dashboard " & "WHERE ID = @ID")
				InsertCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID)
				InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray()
				InsertCommand.Connection = connection
				InsertCommand.ExecuteNonQuery()

				connection.Close()
			End Using

		End Sub

	End Class
End Namespace
