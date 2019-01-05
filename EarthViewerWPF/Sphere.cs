using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace EarthViewerWPF
{
    public class Sphere : UIElement3D
    {
        /// <summary>
        /// Whole 3D model initialized. 
        /// </summary>

        private static int longitudeCount = 144;
        private static int latitudeCount = 72;

        private static readonly DependencyProperty modelProperty = DependencyProperty.Register("Model", typeof(GeometryModel3D), typeof(Sphere), new PropertyMetadata(ModelChanged));
        private GeometryModel3D Model
        {
            get
            {
                return (GeometryModel3D)GetValue(modelProperty);
            }

            set
            {
                SetValue(modelProperty, value);
            }
        }

        private static void ModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sphere sphere = (Sphere)d;
            sphere.Visual3DModel = sphere.Model;
        }

        /// <summary>
        /// Method for creating the sphere's longitudinal polygons. 
        /// </summary>
        public static readonly DependencyProperty longitudesProperty = DependencyProperty.Register("Longitudes", typeof(int), typeof(Sphere), new PropertyMetadata(longitudeCount, new PropertyChangedCallback(LongitudesChanged)));
        public int Longitudes
        {
            get { return (int)GetValue(longitudesProperty); }
            set { SetValue(longitudesProperty, value); }
        }

        private static void LongitudesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sphere sphere = (Sphere)d;
            sphere.InvalidateModel();
        }

        /// <summary>
        /// Method for creating the sphere's latitudinal polygons. 
        /// </summary>
        public static readonly DependencyProperty latitudesProperty = DependencyProperty.Register("Latitudes", typeof(int), typeof(Sphere), new PropertyMetadata(latitudeCount, new PropertyChangedCallback(LongitudesChanged)));
        public int Latitudes
        {
            get { return (int)GetValue(latitudesProperty); }
            set { SetValue(latitudesProperty, value); }
        }

        private static void LatitudesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sphere sphere = (Sphere)d;
            sphere.InvalidateModel();
        }

        /// <summary>
        /// Method for creating the sphere's radius (flatness).
        /// </summary>
        public static readonly DependencyProperty radiusProperty = DependencyProperty.Register("Radius", typeof(int), typeof(Sphere), new PropertyMetadata(1, new PropertyChangedCallback(RadiusChanged)));
        public int Radius
        {
            get { return (int)GetValue(radiusProperty); }
            set { SetValue(radiusProperty, value); }
        }

        private static void RadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sphere sphere = (Sphere)d;
            sphere.InvalidateModel();
        }

        /// <summary>
        /// Method for creating the sphere's material. 
        /// </summary>
        public static readonly DependencyProperty materialProperty = DependencyProperty.Register("Material", typeof(Material), typeof(Sphere), new PropertyMetadata(new DiffuseMaterial(Brushes.Aqua), new PropertyChangedCallback(MaterialChanged)));
        public DiffuseMaterial Material
        {
            get { return (DiffuseMaterial)GetValue(materialProperty); }
            set { SetValue(materialProperty, value); }
        }

        private static void MaterialChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sphere sphere = (Sphere)d;
            if (sphere.Model != null)
            {
                sphere.Model.Material = (Material)e.NewValue;
            }
        }

        /// <summary>
        /// Method for validating the model when a property is changed. 
        /// </summary>
        protected override void OnUpdateModel()
        {
            GeometryModel3D model = new GeometryModel3D();
            model.Geometry = CalculateGeometries(Latitudes, Longitudes, Radius);
            model.Material = (Material)GetValue(materialProperty);
            Model = model;
        }

        /// <summary>
        /// Method for calculating geometries. 
        /// </summary>
        private Geometry3D CalculateGeometries(int Latitudes, int Longitudes, int Radius)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            for (int latitude = 0; latitude <= Latitudes; latitude++)
            {
                double pi = Math.PI / 2 - latitude * Math.PI / Latitudes;
                double y = Math.Sin(pi);
                double radius = -Math.Cos(pi);
                for (int longitude = 0; longitude <= Longitudes; longitude++)
                {
                    double theta = longitude * 2 * Math.PI / Longitudes;
                    double x = radius * Math.Sin(theta);
                    double z = radius * Math.Cos(theta);
                    meshGeometry.Positions.Add(new Point3D(x, y, z));
                    meshGeometry.Normals.Add(new Vector3D(x, y, z));
                    meshGeometry.TextureCoordinates.Add(new Point((double)longitude / Longitudes, (double)latitude / Latitudes));
                }
            }
            for (int latitude = 0; latitude < Latitudes; latitude++)
            {
                for (int longitude = 0; longitude < Longitudes; longitude++)
                {
                    meshGeometry.TriangleIndices.Add(latitude * (Longitudes + 1) + longitude);
                    meshGeometry.TriangleIndices.Add((latitude + 1) * (Longitudes + 1) + longitude);
                    meshGeometry.TriangleIndices.Add(latitude * (Longitudes + 1) + longitude + 1);
                    meshGeometry.TriangleIndices.Add(latitude * (Longitudes + 1) + longitude + 1);
                    meshGeometry.TriangleIndices.Add((latitude + 1) * (Longitudes + 1) + longitude);
                    meshGeometry.TriangleIndices.Add((latitude + 1) * (Longitudes + 1) + longitude + 1);
                }
            }
            meshGeometry.Freeze();
            return meshGeometry;
        }
    }
}