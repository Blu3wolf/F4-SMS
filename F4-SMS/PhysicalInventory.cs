using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace F4SMS
{
	/* Responsible for providing information on actual load. Stores information about load.
	 * Knows which RIUs are xmitting on the 1553 Mux, 
	 * which racks are loaded, what stations they are at, what stores are on them */

	public enum Ammunition
	{
		M56, PGU28
	}

	public enum Rack
	{
		L129, S210, S301, WWP, NJETT, S951, TER, LAU88, LAU117, LAU118, SUU20
	}



	class PhysicalInventory
	{
		public PhysicalInventory()
		{

		}

		int ammo;

		public int Ammo { get => ammo; }

		internal Store[] Stations;

		internal void XmlLoadInv(XmlSchemaSet set)
		{
			Stream MyStream = null;
			OpenFileDialog openInventoryDialog = new OpenFileDialog();

			openInventoryDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openInventoryDialog.Filter = "INV files (*.inv)|*.inv|cfg files (*.cfg)|*.cfg|All files (*.*)|*.*";
			openInventoryDialog.FilterIndex = 1;
			openInventoryDialog.RestoreDirectory = true;

			if (openInventoryDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((MyStream = openInventoryDialog.OpenFile()) != null)
					{
						using (MyStream)
						{
							// insert stream-reading code here... when you work out how
							XmlReaderSettings settings = new XmlReaderSettings();
							settings.Schemas = set;
							using (XmlReader reader = XmlReader.Create(MyStream, settings))
							{
								while (reader.Read())
								{

								}
							}

						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
		}
	}
}
