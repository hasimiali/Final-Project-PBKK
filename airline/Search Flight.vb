Imports System.Data.SqlClient

Public Class Search_Flight
    Dim con As New SqlConnection
    Dim dt As New DataTable
    Dim adp As SqlDataAdapter
    Private Const ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=D:\My Learning\Aplikasi\Airline Reservation System\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(ConnectionString)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT AirlineName, FlightNo, DepartureTime, ArrivalTime, WeekDays FROM aircraft, flights, sector " &
                    "WHERE aircraft.AircraftTypeId = flights.AircraftTypeId AND Flights.sectorid = sector.sectorid " &
                    "AND Source = @Source AND Destination = @Destination"

        Dim SampleSource As New DataSet
        Dim TableView As DataView

        Try
            Using con As New SqlConnection
                con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=D:\MY LEARNING\APLIKASI\AIRLINE RESERVATION SYSTEM\AIRLINE\AIRLINERESERVATIONSYSTEM.MDF;Integrated Security=True;Connect Timeout=5;"
                con.Open()

                Using SampleCommand As New SqlCommand(SelectQry, con)
                    SampleCommand.Parameters.AddWithValue("@Source", Source.Text)
                    SampleCommand.Parameters.AddWithValue("@Destination", Destination.Text)

                    Using SampleDataAdapter As New SqlDataAdapter(SampleCommand)
                        SampleDataAdapter.Fill(SampleSource)
                        TableView = SampleSource.Tables(0).DefaultView
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return TableView
    End Function

    Sub populatesource()
        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=D:\MY LEARNING\APLIKASI\AIRLINE RESERVATION SYSTEM\AIRLINE\AIRLINERESERVATIONSYSTEM.MDF;Integrated Security=True;Connect Timeout=5;"
        conn.Open()

        Dim sql As New SqlCommand("Select distinct Source from Sector", conn)
        sql.CommandType = CommandType.Text

        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = sql
        adapt.SelectCommand.ExecuteNonQuery()

        Dim dset As New DataSet
        adapt.Fill(dset, "Sector")

        conn.Close()
        Source.DataSource = dset.Tables("sector")
        Source.DisplayMember = "source"
        Source.ValueMember = "source"

    End Sub
    Sub populatedestination()


        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=D:\MY LEARNING\APLIKASI\AIRLINE RESERVATION SYSTEM\AIRLINE\AIRLINERESERVATIONSYSTEM.MDF;Integrated Security=True;Connect Timeout=5;"
        conn.Open()

        Dim sql As New SqlCommand("Select distinct destination from sector", conn)
        sql.CommandType = CommandType.Text

        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = sql
        adapt.SelectCommand.ExecuteNonQuery()

        Dim dset As New DataSet
        adapt.Fill(dset, "sector")

        conn.Close()
        Destination.DataSource = dset.Tables("sector")
        Destination.DisplayMember = "destination"
        Destination.ValueMember = "destination"

    End Sub

    Private Sub Search_Flight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
        populatesource()
        populatedestination()
        Source.Text = "select"
        Destination.Text = "select"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Visible = True
        DataGridView1.DataSource = GetData()
    End Sub
    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button1, "serach flights between entered two locations")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Home.Show()

    End Sub
    Private Sub Button2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button1, "fOR EXIT")
    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub Source_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Source.SelectedIndexChanged

    End Sub
End Class