using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;


namespace LayerOfMaps
{
    public class FeatureLayerInspector : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public FeatureLayerInspector()
        {
        }

        protected override void OnClick()
        {
            string data = "";
            IMxDocument mxdoc = ArcMap.Application.Document as IMxDocument;
            ILayer selectedLayer = mxdoc.SelectedLayer;

            if (selectedLayer != null)
            {
                if (selectedLayer is IFeatureLayer2)
                {
                    IDataset dataset = selectedLayer as IDataset;


                    IFeatureLayer2 selectedFL = selectedLayer as IFeatureLayer2;
                    string currentExtension = selectedFL.DataSourceType.ToString();
                    if (currentExtension.Contains("Shapefile"))
                    {
                        currentExtension = ".shp";
                    }
                    else currentExtension = "";

                    data += "Name of layer: " + selectedLayer.Name + "\r\n";
                    data += "Data Source Type :" + selectedFL.DataSourceType + "\r\n";
                    data += "File Path: " + dataset.Workspace.PathName +"\\"+
                            dataset.Name + currentExtension +"\r\n";

                }
                else if (selectedLayer is IRasterLayer)
                {
                    IRasterLayer selectedRL = selectedLayer as IRasterLayer;
                    data += "Name of layer: " + selectedRL.Name + "\r\n";
                    data += "File Path: " + selectedRL.FilePath + "\r\n";
           
                }
            }
            Message msgForm = new Message();
            msgForm.Text = "Result";
            msgForm.lbl.Text = data;
            msgForm.ShowDialog();
            

  
        }

        protected override void OnUpdate()
        {
        }
    }
}
