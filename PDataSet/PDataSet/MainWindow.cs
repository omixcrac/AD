using Gtk;
using Npgsql;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}
	
	
	private void Show(DataTable dataTable){
		//foreach (DataColumn dataColumn in dataTable.Columns)
		//	Console.WriteLine("Column.Name={0}", dataColumn.ColumnName);
		
		foreach (DataRow dataRow in dataTable.Rows){
			foreach (DataColumn dataColumn in dataTable.Columns)
				Console.Write("[{0}={1}]", dataColumn.ColumnName, dataRow[dataColumn]);
			Console.WriteLine();
		}
	}

	protected void OnPropertiesActionActivated (object sender, System.EventArgs e)
	{
		string connectionString = "Server=localhost; Database=pruebaBD; Id=ximo; password=admin";
		
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		IDbCommand selectCommand = dbConnection.CreateCommand();
		
		selectCommand.CommandText = "select * BaseDatos1.from articulo";
		
		IDbDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
		dbDataAdapter.SelectCommand = selectCommand;
		
		DataSet dataSet = new DataSet();
		
		dbDataAdapter.Fill (dataSet);
		
		
		Console.WriteLine("Tables.Count={0}, dataSet.Tables.Count");
		
			foreach (DataTable dataTable in dataSet.Tables){
			Show(dataTable);
		}

	
	}
}