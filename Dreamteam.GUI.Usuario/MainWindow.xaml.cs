using DreamTeam.BIZ;
using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using DreamTeam.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dreamteam.GUI.Usuario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        #region MANEJADORES
        IManejadorPortero manejadorPortero;
        IManejadorDefensa manejadorDefensa;
        IManejadorMediocampo manejadorMediocampo;
        IManejadorDelantero manejadorDelantero;
        #endregion

        #region ACCIONES
        accion accionPortero;
        accion accionDefensa;
        accion accionMediocampo;
        accion accionDelantero;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            BotonesModoEdicion(false);
            BotonesModoEdicionDefensa(false);
            BotonesModoEdicionMediocampo(false);
            BotonesModoEdicionDelantero(false);
            LimpiarCamposPortero();
            LimpiarCamposDefensa();
            LimpiarCamposMediocampo();
            LimpiarCamposDelantero();
            ActualizarTablaPortero();
            ActualizarTablaDefensa();
            ActualizarTablaMediocampo();
            ActualizarTablaDelantero();
            OcultarElementosFormaciones();

        }

        private void OcultarElementosFormaciones()
        {
            lblTituloDefensiva.Visibility = System.Windows.Visibility.Hidden;
            stckDefensiva.Visibility = System.Windows.Visibility.Hidden;
            lblTituloEquilibrada.Visibility = System.Windows.Visibility.Hidden;
            stckEquilibrada1.Visibility = System.Windows.Visibility.Hidden;
            stckEquilibrada2.Visibility = System.Windows.Visibility.Hidden;
            lblTituloOfensiva.Visibility = System.Windows.Visibility.Hidden;
            stckOfensiva1.Visibility = System.Windows.Visibility.Hidden;
            stckCaracteristica.Visibility = Visibility.Hidden;
            lblPortero.Visibility = Visibility.Hidden;
            lblDefensa.Visibility = Visibility.Hidden;
            lblMediocampo.Visibility = Visibility.Hidden;
            lblDelantero.Visibility = Visibility.Hidden;
            btnVolver.Visibility = Visibility.Hidden;
        }

        private void BotonesModoEdicion(bool value)
        {
            btnPorteroCancelar.IsEnabled = value;
            btnPorteroEditar.IsEnabled = !value;
            btnPorteroEliminar.IsEnabled = !value;
            btnPorteroGuardar.IsEnabled = value;
            btnPorteroNuevo.IsEnabled = !value;
        }
        private void BotonesModoEdicionDefensa(bool value)
        {
            btnDefensaCancelar.IsEnabled = value;
            btnDefensaEditar.IsEnabled = !value;
            btnDefensaEliminar.IsEnabled = !value;
            btnDefensaGuardar.IsEnabled = value;
            btnDefensaNuevo.IsEnabled = !value;
        }
        private void BotonesModoEdicionMediocampo(bool value)
        {
            btnMediocampoCancelar.IsEnabled = value;
            btnMediocampoEditar.IsEnabled = !value;
            btnMediocampoEliminar.IsEnabled = !value;
            btnMediocampoGuardar.IsEnabled = value;
            btnMediocampoNuevo.IsEnabled = !value;
        }
        private void BotonesModoEdicionDelantero(bool value)
        {
            btnDelanteroCancelar.IsEnabled = value;
            btnDelanteroEditar.IsEnabled = !value;
            btnDelanteroEliminar.IsEnabled = !value;
            btnDelanteroGuardar.IsEnabled = value;
            btnDelanteroNuevo.IsEnabled = !value;
        }

        #region CRUD PORTERO
        //
        //DESARROLLO DE PORTERO
        //
        private void ActualizarTablaPortero()
        {
            manejadorPortero = new ManejadorPortero(new RepositorioPortero());
            dtgPortero.ItemsSource = null;
            dtgPortero.ItemsSource = manejadorPortero.Listar;

        }

        private void LimpiarCamposPortero()
        {
            txbPorteroId.Text = "";
            txbPorteroAltura.Clear();
            txbPorteroDefensaVal.Clear();
            txbPorteroEdad.Clear();
            txbPorteroFisicoVal.Clear();
            txbPorteroHabilidadBalon.Clear();
            txbPorteroMentalVal.Clear();
            txbPorteroNombre.Clear();
            txbPorteroPaseVal.Clear();
            txbPorteroPeso.Clear();
            //txbPorteroPieHabil.Clear();
            txbPorteroPorteroVal.Clear();
            //txbPorteroPosicionEspecifica.Clear();
            txbPorteroPrecio.Clear();
            txbPorteroSueldo.Clear();
            txbPorteroTirosVal.Clear();
        }

        private void BtnPorteroNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposPortero();
            BotonesModoEdicion(true);
            accionPortero = accion.Nuevo;
        }

        private void BtnPorteroEditar_Click(object sender, RoutedEventArgs e)
        {
            Portero port = dtgPortero.SelectedItem as Portero;
            if (port != null)
            {
                txbPorteroAltura.Text = Convert.ToString(port.Altura);
                txbPorteroDefensaVal.Text = Convert.ToString(port.DefensaVal);
                txbPorteroEdad.Text = Convert.ToString(port.Edad);
                txbPorteroFisicoVal.Text = Convert.ToString(port.FisicoVal);
                txbPorteroHabilidadBalon.Text = Convert.ToString(port.HabilidadBalon);
                txbPorteroId.Text = port.Id;
                txbPorteroMentalVal.Text = Convert.ToString(port.MentalVal);
                txbPorteroNombre.Text = port.Nombre;
                txbPorteroPaseVal.Text = Convert.ToString(port.PaseVal);
                txbPorteroPeso.Text = Convert.ToString(port.Peso);
                txbPorteroPieHabil.Text = port.PieHabil;
                txbPorteroPorteroVal.Text = Convert.ToString(port.PorteroVal);
                txbPorteroPosicionEspecifica.Text = port.PosicionEspecifica;
                txbPorteroPrecio.Text = Convert.ToString(port.Precio);
                txbPorteroSueldo.Text = Convert.ToString(port.Sueldo);
                txbPorteroTirosVal.Text = Convert.ToString(port.TirosVal);
                accionPortero = accion.Editar;
                BotonesModoEdicion(true);
            }
        }

        private void BtnPorteroGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionPortero == accion.Nuevo)
            {
                Portero port = new Portero()
                {
                    Altura = Convert.ToInt32(txbPorteroAltura.Text),
                    DefensaVal = Convert.ToInt32(txbPorteroDefensaVal.Text),
                    Edad = Convert.ToInt32(txbPorteroEdad.Text),
                    FisicoVal = Convert.ToInt32(txbPorteroFisicoVal.Text),
                    HabilidadBalon = Convert.ToInt32(txbPorteroHabilidadBalon.Text),
                    Id = txbPorteroId.Text,
                    MentalVal = Convert.ToInt32(txbPorteroMentalVal.Text),
                    Nombre = txbPorteroNombre.Text,
                    PaseVal = Convert.ToInt32(txbPorteroPaseVal.Text),
                    Peso = Convert.ToInt32(txbPorteroPeso.Text),
                    PieHabil = txbPorteroPieHabil.Text,
                    PorteroVal = Convert.ToInt32(txbPorteroPorteroVal.Text),
                    PosicionEspecifica = txbPorteroPosicionEspecifica.Text,
                    Precio = Convert.ToInt32(txbPorteroPrecio.Text),
                    Sueldo = Convert.ToInt32(txbPorteroSueldo.Text),
                    TirosVal = Convert.ToInt32(txbPorteroTirosVal.Text)
                };
                if (manejadorPortero.Agregar(port))
                {
                    MessageBox.Show("Jugador registrado correctamente.", "Portero", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposPortero();
                    ActualizarTablaPortero();
                    BotonesModoEdicion(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar un nuevo jugador.", "Portero", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Portero port = dtgPortero.SelectedItem as Portero;

                port.Altura = Convert.ToInt32(txbPorteroAltura.Text);
                port.DefensaVal = Convert.ToInt32(txbPorteroDefensaVal.Text);
                port.Edad = Convert.ToInt32(txbPorteroEdad.Text);
                port.FisicoVal = Convert.ToInt32(txbPorteroFisicoVal.Text);
                port.HabilidadBalon = Convert.ToInt32(txbPorteroHabilidadBalon.Text);
                port.Id = txbPorteroId.Text;
                port.MentalVal = Convert.ToInt32(txbPorteroMentalVal.Text);
                port.Nombre = txbPorteroNombre.Text;
                port.PaseVal = Convert.ToInt32(txbPorteroPaseVal.Text);
                port.Peso = Convert.ToInt32(txbPorteroPeso.Text);
                port.PieHabil = txbPorteroPieHabil.Text;
                port.PorteroVal = Convert.ToInt32(txbPorteroPorteroVal.Text);
                port.PosicionEspecifica = txbPorteroPosicionEspecifica.Text;
                port.Precio = Convert.ToInt32(txbPorteroPrecio.Text);
                port.Sueldo = Convert.ToInt32(txbPorteroSueldo.Text);
                port.TirosVal = Convert.ToInt32(txbPorteroTirosVal.Text);

                if (manejadorPortero.Modificar(port))
                {
                    MessageBox.Show("Datos de jugador modificados correctamente.", "Portero", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposPortero();
                    ActualizarTablaPortero();
                    BotonesModoEdicion(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar jugador.", "Portero", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnPorteroCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposPortero();
            BotonesModoEdicion(false);
        }

        private void BtnPorteroEliminar_Click(object sender, RoutedEventArgs e)
        {
            Portero port = dtgPortero.SelectedItem as Portero;
            if (port != null)
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar los datos de este jugador?", "Portero", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorPortero.Eliminar(port.Id))
                    {
                        MessageBox.Show("Jugador eliminado de los registros.", "Portero", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaPortero();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar jugador.", "Portero", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //
        //FIN DESARROLLO PORTERO
        //
        #endregion

        #region CRUD DEFENSA
        //
        //DESARROLLO DE DEFENSA
        //
        private void ActualizarTablaDefensa()
        {
            manejadorDefensa = new ManejadorDefensa(new RepositorioDefensa());
            dtgDefensa.ItemsSource = null;
            dtgDefensa.ItemsSource = manejadorDefensa.Listar;
        }

        private void LimpiarCamposDefensa()
        {
            txbDefensaId.Text = "";
            txbDefensaAltura.Clear();
            txbDefensaDefensaVal.Clear();
            txbDefensaEdad.Clear();
            txbDefensaFisicoVal.Clear();
            txbDefensaHabilidadBalon.Clear();
            txbDefensaMentalVal.Clear();
            txbDefensaNombre.Clear();
            txbDefensaPaseVal.Clear();
            txbDefensaPeso.Clear();
            //txbDefensaPieHabil.Clear();
            txbDefensaPorteroVal.Clear();
            //txbDefensaPosicionEspecifica.Items.Clear();
            txbDefensaPrecio.Clear();
            txbDefensaSueldo.Clear();
            txbDefensaTirosVal.Clear();
        }

        private void BtnDefensaNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDefensa();
            BotonesModoEdicionDefensa(true);
            accionDefensa = accion.Nuevo;
        }

        private void BtnDefensaEditar_Click(object sender, RoutedEventArgs e)
        {
            Defensa def = dtgDefensa.SelectedItem as Defensa;
            if (def != null)
            {
                txbDefensaAltura.Text = Convert.ToString(def.Altura);
                txbDefensaDefensaVal.Text = Convert.ToString(def.DefensaVal);
                txbDefensaEdad.Text = Convert.ToString(def.Edad);
                txbDefensaFisicoVal.Text = Convert.ToString(def.FisicoVal);
                txbDefensaHabilidadBalon.Text = Convert.ToString(def.HabilidadBalon);
                txbDefensaId.Text = def.Id;
                txbDefensaMentalVal.Text = Convert.ToString(def.MentalVal);
                txbDefensaNombre.Text = def.Nombre;
                txbDefensaPaseVal.Text = Convert.ToString(def.PaseVal);
                txbDefensaPeso.Text = Convert.ToString(def.Peso);
                txbDefensaPieHabil.Text = def.PieHabil;
                txbDefensaPorteroVal.Text = Convert.ToString(def.PorteroVal);
                txbDefensaPosicionEspecifica.Text = def.PosicionEspecifica;
                txbDefensaPrecio.Text = Convert.ToString(def.Precio);
                txbDefensaSueldo.Text = Convert.ToString(def.Sueldo);
                txbDefensaTirosVal.Text = Convert.ToString(def.TirosVal);
                accionDefensa = accion.Editar;
                BotonesModoEdicionDefensa(true);
            }
        }

        private void BtnDefensaGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionDefensa == accion.Nuevo)
            {
                Defensa def = new Defensa()
                {
                    Altura = Convert.ToInt32(txbDefensaAltura.Text),
                    DefensaVal = Convert.ToInt32(txbDefensaDefensaVal.Text),
                    Edad = Convert.ToInt32(txbDefensaEdad.Text),
                    FisicoVal = Convert.ToInt32(txbDefensaFisicoVal.Text),
                    HabilidadBalon = Convert.ToInt32(txbDefensaHabilidadBalon.Text),
                    Id = txbDefensaId.Text,
                    MentalVal = Convert.ToInt32(txbDefensaMentalVal.Text),
                    Nombre = txbDefensaNombre.Text,
                    PaseVal = Convert.ToInt32(txbDefensaPaseVal.Text),
                    Peso = Convert.ToInt32(txbDefensaPeso.Text),
                    PieHabil = txbDefensaPieHabil.Text,
                    PorteroVal = Convert.ToInt32(txbDefensaPorteroVal.Text),
                    PosicionEspecifica = txbDefensaPosicionEspecifica.Text,
                    Precio = Convert.ToInt32(txbDefensaPrecio.Text),
                    Sueldo = Convert.ToInt32(txbDefensaSueldo.Text),
                    TirosVal = Convert.ToInt32(txbDefensaTirosVal.Text)
                };
                if (manejadorDefensa.Agregar(def))
                {
                    MessageBox.Show("Jugador registrado correctamente.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDefensa();
                    ActualizarTablaDefensa();
                    BotonesModoEdicionDefensa(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar un nuevo jugador.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Defensa def = dtgDefensa.SelectedItem as Defensa;

                def.Altura = Convert.ToInt32(txbDefensaAltura.Text);
                def.DefensaVal = Convert.ToInt32(txbDefensaDefensaVal.Text);
                def.Edad = Convert.ToInt32(txbDefensaEdad.Text);
                def.FisicoVal = Convert.ToInt32(txbDefensaFisicoVal.Text);
                def.HabilidadBalon = Convert.ToInt32(txbDefensaHabilidadBalon.Text);
                def.Id = txbDefensaId.Text;
                def.MentalVal = Convert.ToInt32(txbDefensaMentalVal.Text);
                def.Nombre = txbDefensaNombre.Text;
                def.PaseVal = Convert.ToInt32(txbDefensaPaseVal.Text);
                def.Peso = Convert.ToInt32(txbDefensaPeso.Text);
                def.PieHabil = txbDefensaPieHabil.Text;
                def.PorteroVal = Convert.ToInt32(txbDefensaPorteroVal.Text);
                def.PosicionEspecifica = txbDefensaPosicionEspecifica.Text;
                def.Precio = Convert.ToInt32(txbDefensaPrecio.Text);
                def.Sueldo = Convert.ToInt32(txbDefensaSueldo.Text);
                def.TirosVal = Convert.ToInt32(txbDefensaTirosVal.Text);

                if (manejadorDefensa.Modificar(def))
                {
                    MessageBox.Show("Datos de jugador modificados correctamente.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDefensa();
                    ActualizarTablaDefensa();
                    BotonesModoEdicionDefensa(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar jugador.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDefensaCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDefensa();
            BotonesModoEdicionDefensa(false);
        }

        private void BtnDefensaEliminar_Click(object sender, RoutedEventArgs e)
        {
            Defensa def = dtgDefensa.SelectedItem as Defensa;
            if (def != null)
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar los datos de este jugador?", "Defensa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDefensa.Eliminar(def.Id))
                    {
                        MessageBox.Show("Jugador eliminado de los registros.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaDefensa();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar jugador.", "Defensa", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //
        //FIN DESARROLLO DEFENSA
        //
        #endregion

        #region CRUD MEDIO CAMPO
        //
        //DESARROLLO DE MEDIOCAMPO
        //

        private void ActualizarTablaMediocampo()
        {
            manejadorMediocampo = new ManejadorMediocampo(new RepositorioMediocampo());
            dtgMediocampo.ItemsSource = null;
            dtgMediocampo.ItemsSource = manejadorMediocampo.Listar;
        }

        private void LimpiarCamposMediocampo()
        {
            txbMediocampoId.Text = "";
            txbMediocampoAltura.Clear();
            txbMediocampoDefensaVal.Clear();
            txbMediocampoEdad.Clear();
            txbMediocampoFisicoVal.Clear();
            txbMediocampoHabilidadBalon.Clear();
            txbMediocampoMentalVal.Clear();
            txbMediocampoNombre.Clear();
            txbMediocampoPaseVal.Clear();
            txbMediocampoPeso.Clear();
            //txbMediocampoPieHabil.Clear();
            txbMediocampoPorteroVal.Clear();
            //txbMediocampoPosicionEspecifica.Clear();
            txbMediocampoPrecio.Clear();
            txbMediocampoSueldo.Clear();
            txbMediocampoTirosVal.Clear();
        }

        private void BtnMediocampoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposMediocampo();
            BotonesModoEdicionMediocampo(true);
            accionMediocampo = accion.Nuevo;
        }

        private void BtnMediocampoEditar_Click(object sender, RoutedEventArgs e)
        {
            Mediocampo med = dtgMediocampo.SelectedItem as Mediocampo;
            if (med != null)
            {
                txbMediocampoAltura.Text = Convert.ToString(med.Altura);
                txbMediocampoDefensaVal.Text = Convert.ToString(med.DefensaVal);
                txbMediocampoEdad.Text = Convert.ToString(med.Edad);
                txbMediocampoFisicoVal.Text = Convert.ToString(med.FisicoVal);
                txbMediocampoHabilidadBalon.Text = Convert.ToString(med.HabilidadBalon);
                txbMediocampoId.Text = med.Id;
                txbMediocampoMentalVal.Text = Convert.ToString(med.MentalVal);
                txbMediocampoNombre.Text = med.Nombre;
                txbMediocampoPaseVal.Text = Convert.ToString(med.PaseVal);
                txbMediocampoPeso.Text = Convert.ToString(med.Peso);
                txbMediocampoPieHabil.Text = med.PieHabil;
                txbMediocampoPorteroVal.Text = Convert.ToString(med.PorteroVal);
                txbMediocampoPosicionEspecifica.Text = med.PosicionEspecifica;
                txbMediocampoPrecio.Text = Convert.ToString(med.Precio);
                txbMediocampoSueldo.Text = Convert.ToString(med.Sueldo);
                txbMediocampoTirosVal.Text = Convert.ToString(med.TirosVal);
                accionMediocampo = accion.Editar;
                BotonesModoEdicionMediocampo(true);
            }
        }

        private void BtnMediocampoGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionMediocampo == accion.Nuevo)
            {
                Mediocampo med = new Mediocampo()
                {
                    Altura = Convert.ToInt32(txbMediocampoAltura.Text),
                    DefensaVal = Convert.ToInt32(txbMediocampoDefensaVal.Text),
                    Edad = Convert.ToInt32(txbMediocampoEdad.Text),
                    FisicoVal = Convert.ToInt32(txbMediocampoFisicoVal.Text),
                    HabilidadBalon = Convert.ToInt32(txbMediocampoHabilidadBalon.Text),
                    Id = txbMediocampoId.Text,
                    MentalVal = Convert.ToInt32(txbMediocampoMentalVal.Text),
                    Nombre = txbMediocampoNombre.Text,
                    PaseVal = Convert.ToInt32(txbMediocampoPaseVal.Text),
                    Peso = Convert.ToInt32(txbMediocampoPeso.Text),
                    PieHabil = txbMediocampoPieHabil.Text,
                    PorteroVal = Convert.ToInt32(txbMediocampoPorteroVal.Text),
                    PosicionEspecifica = txbMediocampoPosicionEspecifica.Text,
                    Precio = Convert.ToInt32(txbMediocampoPrecio.Text),
                    Sueldo = Convert.ToInt32(txbMediocampoSueldo.Text),
                    TirosVal = Convert.ToInt32(txbMediocampoTirosVal.Text)
                };
                if (manejadorMediocampo.Agregar(med))
                {
                    MessageBox.Show("Jugador registrado correctamente.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposMediocampo();
                    ActualizarTablaMediocampo();
                    BotonesModoEdicionMediocampo(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar un nuevo jugador.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Mediocampo med = dtgMediocampo.SelectedItem as Mediocampo;

                med.Altura = Convert.ToInt32(txbMediocampoAltura.Text);
                med.DefensaVal = Convert.ToInt32(txbMediocampoDefensaVal.Text);
                med.Edad = Convert.ToInt32(txbMediocampoEdad.Text);
                med.FisicoVal = Convert.ToInt32(txbMediocampoFisicoVal.Text);
                med.HabilidadBalon = Convert.ToInt32(txbMediocampoHabilidadBalon.Text);
                med.Id = txbMediocampoId.Text;
                med.MentalVal = Convert.ToInt32(txbMediocampoMentalVal.Text);
                med.Nombre = txbMediocampoNombre.Text;
                med.PaseVal = Convert.ToInt32(txbMediocampoPaseVal.Text);
                med.Peso = Convert.ToInt32(txbMediocampoPeso.Text);
                med.PieHabil = txbMediocampoPieHabil.Text;
                med.PorteroVal = Convert.ToInt32(txbMediocampoPorteroVal.Text);
                med.PosicionEspecifica = txbMediocampoPosicionEspecifica.Text;
                med.Precio = Convert.ToInt32(txbMediocampoPrecio.Text);
                med.Sueldo = Convert.ToInt32(txbMediocampoSueldo.Text);
                med.TirosVal = Convert.ToInt32(txbMediocampoTirosVal.Text);

                if (manejadorMediocampo.Modificar(med))
                {
                    MessageBox.Show("Datos de jugador modificados correctamente.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposMediocampo();
                    ActualizarTablaMediocampo();
                    BotonesModoEdicionMediocampo(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar jugador.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnMediocampoCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposMediocampo();
            BotonesModoEdicionMediocampo(false);
        }

        private void BtnMediocampoEliminar_Click(object sender, RoutedEventArgs e)
        {
            Mediocampo med = dtgMediocampo.SelectedItem as Mediocampo;
            if (med != null)
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar los datos de este jugador?", "Mediocampo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorMediocampo.Eliminar(med.Id))
                    {
                        MessageBox.Show("Jugador eliminado de los registros.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaMediocampo();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar jugador.", "Mediocampo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //
        //FIN DESARROLLO MEDIOCAMPO
        //
        #endregion

        #region CRUD DELANTERO
        //
        //DESARROLLO DE DELANTERO
        //

        private void ActualizarTablaDelantero()
        {
            manejadorDelantero = new ManejadorDelantero(new RepositorioDelantero());
            dtgDelantero.ItemsSource = null;
            dtgDelantero.ItemsSource = manejadorDelantero.Listar;
        }

        private void LimpiarCamposDelantero()
        {
            txbDelanteroId.Text = "";
            txbDelanteroAltura.Clear();
            txbDelanteroDefensaVal.Clear();
            txbDelanteroEdad.Clear();
            txbDelanteroFisicoVal.Clear();
            txbDelanteroHabilidadBalon.Clear();
            txbDelanteroMentalVal.Clear();
            txbDelanteroNombre.Clear();
            txbDelanteroPaseVal.Clear();
            txbDelanteroPeso.Clear();
            //txbDelanteroPieHabil.Clear();
            txbDelanteroPorteroVal.Clear();
            //txbDelanteroPosicionEspecifica.Clear();
            txbDelanteroPrecio.Clear();
            txbDelanteroSueldo.Clear();
            txbDelanteroTirosVal.Clear();
        }

        private void BtnDelanteroNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDelantero();
            BotonesModoEdicionDelantero(true);
            accionDelantero = accion.Nuevo;
        }

        private void BtnDelanteroEditar_Click(object sender, RoutedEventArgs e)
        {
            Delantero del = dtgDelantero.SelectedItem as Delantero;
            if (del != null)
            {
                txbDelanteroAltura.Text = Convert.ToString(del.Altura);
                txbDelanteroDefensaVal.Text = Convert.ToString(del.DefensaVal);
                txbDelanteroEdad.Text = Convert.ToString(del.Edad);
                txbDelanteroFisicoVal.Text = Convert.ToString(del.FisicoVal);
                txbDelanteroHabilidadBalon.Text = Convert.ToString(del.HabilidadBalon);
                txbDelanteroId.Text = del.Id;
                txbDelanteroMentalVal.Text = Convert.ToString(del.MentalVal);
                txbDelanteroNombre.Text = del.Nombre;
                txbDelanteroPaseVal.Text = Convert.ToString(del.PaseVal);
                txbDelanteroPeso.Text = Convert.ToString(del.Peso);
                txbDelanteroPieHabil.Text = del.PieHabil;
                txbDelanteroPorteroVal.Text = Convert.ToString(del.PorteroVal);
                txbDelanteroPosicionEspecifica.Text = del.PosicionEspecifica;
                txbDelanteroPrecio.Text = Convert.ToString(del.Precio);
                txbDelanteroSueldo.Text = Convert.ToString(del.Sueldo);
                txbDelanteroTirosVal.Text = Convert.ToString(del.TirosVal);
                accionDelantero = accion.Editar;
                BotonesModoEdicionDelantero(true);
            }
        }

        private void BtnDelanteroGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionDelantero == accion.Nuevo)
            {
                Delantero del = new Delantero()
                {
                    Altura = Convert.ToInt32(txbDelanteroAltura.Text),
                    DefensaVal = Convert.ToInt32(txbDelanteroDefensaVal.Text),
                    Edad = Convert.ToInt32(txbDelanteroEdad.Text),
                    FisicoVal = Convert.ToInt32(txbDelanteroFisicoVal.Text),
                    HabilidadBalon = Convert.ToInt32(txbDelanteroHabilidadBalon.Text),
                    Id = txbDelanteroId.Text,
                    MentalVal = Convert.ToInt32(txbDelanteroMentalVal.Text),
                    Nombre = txbDelanteroNombre.Text,
                    PaseVal = Convert.ToInt32(txbDelanteroPaseVal.Text),
                    Peso = Convert.ToInt32(txbDelanteroPeso.Text),
                    PieHabil = txbDelanteroPieHabil.Text,
                    PorteroVal = Convert.ToInt32(txbDelanteroPorteroVal.Text),
                    PosicionEspecifica = txbDelanteroPosicionEspecifica.Text,
                    Precio = Convert.ToInt32(txbDelanteroPrecio.Text),
                    Sueldo = Convert.ToInt32(txbDelanteroSueldo.Text),
                    TirosVal = Convert.ToInt32(txbDelanteroTirosVal.Text)
                };
                if (manejadorDelantero.Agregar(del))
                {
                    MessageBox.Show("Jugador registrado correctamente.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDelantero();
                    ActualizarTablaDelantero();
                    BotonesModoEdicionDelantero(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar un nuevo jugador.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Delantero del = dtgDelantero.SelectedItem as Delantero;

                del.Altura = Convert.ToInt32(txbDelanteroAltura.Text);
                del.DefensaVal = Convert.ToInt32(txbDelanteroDefensaVal.Text);
                del.Edad = Convert.ToInt32(txbDelanteroEdad.Text);
                del.FisicoVal = Convert.ToInt32(txbDelanteroFisicoVal.Text);
                del.HabilidadBalon = Convert.ToInt32(txbDelanteroHabilidadBalon.Text);
                del.Id = txbDelanteroId.Text;
                del.MentalVal = Convert.ToInt32(txbDelanteroMentalVal.Text);
                del.Nombre = txbDelanteroNombre.Text;
                del.PaseVal = Convert.ToInt32(txbDelanteroPaseVal.Text);
                del.Peso = Convert.ToInt32(txbDelanteroPeso.Text);
                del.PieHabil = txbDelanteroPieHabil.Text;
                del.PorteroVal = Convert.ToInt32(txbDelanteroPorteroVal.Text);
                del.PosicionEspecifica = txbDelanteroPosicionEspecifica.Text;
                del.Precio = Convert.ToInt32(txbDelanteroPrecio.Text);
                del.Sueldo = Convert.ToInt32(txbDelanteroSueldo.Text);
                del.TirosVal = Convert.ToInt32(txbDelanteroTirosVal.Text);

                if (manejadorDelantero.Modificar(del))
                {
                    MessageBox.Show("Datos de jugador modificados correctamente.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDelantero();
                    ActualizarTablaDelantero();
                    BotonesModoEdicionDelantero(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar jugador.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDelanteroCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDelantero();
            BotonesModoEdicionDelantero(false);
        }

        private void BtnDelanteroEliminar_Click(object sender, RoutedEventArgs e)
        {
            Delantero del = dtgDelantero.SelectedItem as Delantero;
            if (del != null)
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar los datos de este jugador?", "Delantero", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDelantero.Eliminar(del.Id))
                    {
                        MessageBox.Show("Jugador eliminado de los registros.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaDelantero();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar jugador.", "Delantero", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //
        //FIN DESARROLLO DELANTERO
        //
        #endregion

        #region visibilidad formaciones
        private void BtnFormacionDefensiva_Click(object sender, RoutedEventArgs e)
        {
            btnFormacionEquilibrada.Visibility = Visibility.Hidden;
            btnFormacionOfensiva.Visibility = Visibility.Hidden;
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionEquilibrada_Click(object sender, RoutedEventArgs e)
        {
            btnFormacionDefensiva.Visibility = Visibility.Hidden;
            btnFormacionOfensiva.Visibility = Visibility.Hidden;
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionOfensiva_Click(object sender, RoutedEventArgs e)
        {
            btnFormacionDefensiva.Visibility = Visibility.Hidden;
            btnFormacionEquilibrada.Visibility = Visibility.Hidden;
            stckCaracteristica.Visibility = Visibility.Visible;
        }
        
        private void ChkJugadoresJovenes_Click(object sender, RoutedEventArgs e)
        {
            if(btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if(btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkHabilidadBalon_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkHabilidadDefensiva_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkHabilidadMental_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkHabilidadPase_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkRendimientoFisico_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }

        private void ChkHabilidadTiroArco_Click(object sender, RoutedEventArgs e)
        {
            if (btnFormacionDefensiva.Visibility == Visibility.Visible)
            {
                lblTituloDefensiva.Visibility = Visibility.Visible;
                stckDefensiva.Visibility = Visibility.Visible;
            }
            else if (btnFormacionEquilibrada.Visibility == Visibility.Visible)
            {
                lblTituloEquilibrada.Visibility = Visibility.Visible;
                stckEquilibrada1.Visibility = Visibility.Visible;
                stckEquilibrada2.Visibility = Visibility.Visible;
            }
            else if (btnFormacionOfensiva.Visibility == Visibility.Visible)
            {
                lblTituloOfensiva.Visibility = Visibility.Visible;
                stckOfensiva1.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region MOSTRAR RESULTADOS FINALES

        private void BtnFormacionDefensiva1_Click(object sender, RoutedEventArgs e)
        {
            if(chkJugadoresJovenes.IsChecked ?? true)
            {
                manejadorPortero = new ManejadorPortero(new RepositorioPortero());
                dtgPorteroSeleccionado.ItemsSource = null;
                dtgPorteroSeleccionado.ItemsSource = manejadorPortero.ListarEdad;

                manejadorDefensa = new ManejadorDefensa(new RepositorioDefensa());
                dtgDefensaSeleccionado.ItemsSource = null;
                dtgDefensaSeleccionado.ItemsSource = manejadorDefensa.ListarEdad;

                manejadorMediocampo = new ManejadorMediocampo(new RepositorioMediocampo());
                dtgMediocampoSeleccionado.ItemsSource = null;
                dtgMediocampoSeleccionado.ItemsSource = manejadorMediocampo.ListarEdad;

                manejadorDelantero = new ManejadorDelantero(new RepositorioDelantero());
                dtgDelanteroSeleccionado.ItemsSource = null;
                dtgDelanteroSeleccionado.ItemsSource = manejadorDelantero.ListarEdad;

                btnVolver.Visibility = Visibility.Visible;
                lblPortero.Visibility = Visibility.Visible;
                lblDefensa.Visibility = Visibility.Visible;
                lblMediocampo.Visibility = Visibility.Visible;
                lblDelantero.Visibility = Visibility.Visible;
            }
            else if(chkJugadoresJovenes.IsChecked ?? true)
            {

            }
            else if (chkJugadoresJovenes.IsChecked ?? true)
            {

            }
            else if (chkJugadoresJovenes.IsChecked ?? true)
            {

            }
            else if (chkJugadoresJovenes.IsChecked ?? true)
            {

            }
            else if (chkJugadoresJovenes.IsChecked ?? true)
            {

            }
            else if (chkJugadoresJovenes.IsChecked ?? true)
            {

            }
        }

        private void BtnFormacionDefensiva2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionDefensiva3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionDefensiva4_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormacionEquilibrada7_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada8_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada9_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada10_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada11_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionEquilibrada12_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionOfensiva1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnFormacionOfensiva1_Click_1(object sender, RoutedEventArgs e)
        {
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionOfensiva2_Click(object sender, RoutedEventArgs e)
        {
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionOfensiva3_Click(object sender, RoutedEventArgs e)
        {
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionOfensiva4_Click(object sender, RoutedEventArgs e)
        {
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        private void BtnFormacionOfensiva5_Click(object sender, RoutedEventArgs e)
        {
            stckCaracteristica.Visibility = Visibility.Visible;
        }

        #endregion

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            dtgPorteroSeleccionado.ItemsSource = null;
            dtgDefensaSeleccionado.ItemsSource = null;
            dtgMediocampoSeleccionado.ItemsSource = null;
            dtgDelanteroSeleccionado.ItemsSource = null;
            btnVolver.Visibility = Visibility.Hidden;
            lblPortero.Visibility = Visibility.Hidden;
            lblDefensa.Visibility = Visibility.Hidden;
            lblMediocampo.Visibility = Visibility.Hidden;
            lblDelantero.Visibility = Visibility.Hidden;
            stckCaracteristica.Visibility = Visibility.Hidden;
            lblTituloDefensiva.Visibility = Visibility.Hidden;
            stckDefensiva.Visibility = Visibility.Hidden;
            lblTituloEquilibrada.Visibility = Visibility.Hidden;
            stckEquilibrada1.Visibility = Visibility.Hidden;
            stckEquilibrada2.Visibility = Visibility.Hidden;
            lblTituloOfensiva.Visibility = Visibility.Hidden;
            stckOfensiva1.Visibility = Visibility.Hidden;
            btnFormacionEquilibrada.Visibility = Visibility.Visible;
            btnFormacionDefensiva.Visibility = Visibility.Visible;
            btnFormacionOfensiva.Visibility = Visibility.Visible;
        }
    }
}
