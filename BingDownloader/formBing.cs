using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

//https://docs.microsoft.com/pt-br/dotnet/api/system.windows.forms.webbrowser.documenttext?view=netcore-3.1
//https://www.codeproject.com/Tips/130267/Call-a-C-Method-From-JavaScript-Hosted-in-a-WebBro

namespace BingDownloader
{
	public partial class FormBing : Form
	{
		// This nested class must be ComVisible for the JavaScript to be able to call it.
		[ComVisible(true)]
		public class ScriptManager
		{
			// Variable to store the form of type Form1.
			private FormBing mForm;

			// Constructor.
			public ScriptManager(FormBing form)
			{
				// Save the form so it can be referenced later.
				mForm = form;
			}

			// This method can be called from JavaScript.
			public void LoadLine(int line)
			{
				// Call a method on the form.
				mForm.SaveImage(line);
			}
		}

		// This method will be called by the other method (LoadLine) that gets called by JavaScript.
		public void SaveImage(int i)
		{
			WebClient cliente = new WebClient();
			string fileName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			if (rdbLayout3.Checked)
			{
				cliente.DownloadFile(this.dgvDisponibilidade.Rows[i].Cells[dgcDispURL.Index].Value.ToString(), dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value.ToString());
				fileName += dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value.ToString();
			}
			else
			{
				cliente.DownloadFile(this.dgvResultado.Rows[i].Cells[dgcURL.Index].Value.ToString(), dgvResultado.Rows[i].Cells[dgcNomeArquivo.Index].Value.ToString());
				fileName += dgvResultado.Rows[i].Cells[dgcNomeArquivo.Index].Value.ToString();
			}
			while (!File.Exists(fileName))
			{
				Application.DoEvents();
			}
			if (rdbLayout3.Checked)
				MessageBox.Show("ARQUIVO " + dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value.ToString() + " SALVO COM SUCESSO!");
			else
			{
				MessageBox.Show("ARQUIVO " + dgvResultado.Rows[i].Cells[dgcNomeArquivo.Index].Value.ToString() + " SALVO COM SUCESSO!");
			}
		}

		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int description, int reservedValue);

		string _codigoFonte;
		readonly string[] _menuPortugues = { " IDIOMA ", "Português", "Inglês", "Espanhol", "LISTA DE PAÍSES DISPONÍVEIS", " RESOLUÇÃO ", " LAYOUT ", "&Detalhado", "&Compacto", "&Todos os não baixados", " NAVEGAÇÃO ", "Cidade &anterior", "Próxima &cidade", "&Salvar todas", "CLIQUE DIREITO PARA SALVAR", "PROCESSADOS XXX DE NNN PAÍSES DISPONÍVEIS - III", "PROCESSAMENTO COMPLETO - III" };
		readonly string[] _menuIngles = { " LANGUAGE ", "Portuguese", "English", "Spanish", "LIST OF COUNTRIES AVAILABLE", " RESOLUTION ", " LAYOUT ", "&Detailed", "&Compact", "&All not downloaded", " NAVIGATION ", "City &previous", "Next &city", "&Save all", "RIGHT CLICK TO SAVE", "PROCESSED XXX FROM NNN AVAILABLE COUNTRIES - III", "COMPLETE PROCESSING - III" };
		readonly string[] _menuEspanhol = { " IDIOMA ", "Portugués", "Inglés", "Español", "LISTA DE PAÍSES DISPONIBLES", " RESOLUCIÓN ", " DISEÑO ", "&Detallado", "&Compacto", "&Todo no descargado", " NAVEGACIÓN ", "Ciudad &anterior", "Siguiente &ciudad", "&Guardar todo", "CLIC DERECHO PARA GUARDAR", "XXX PROCESADO DE NNN PAÍSES DISPONIBLES - III", "PROCESAMIENTO COMPLETO - III" };
		DataTable _dtListaPaises;
		DataView _dvListaPaises;

		public static bool IsConnected()
		{
			int description;
			return InternetGetConnectedState(out description, 0);
		}

		private void CarregarHTML()
		{
			Cursor = Cursors.WaitCursor;
			int i;
			DataRow row;
			if (rdbLayout3.Checked)
			{
				int contador = 0;
				dgvDisponibilidade.Rows.Clear();
				//for (i = 0; i < lsbPaises.Items.Count; i++)
				for (i = 0; i < 10; i++)
				{
					lsbPaises.SelectedIndex = i;
					dgvResultado.Rows.Clear();
					row = _dtListaPaises.Rows[i];
					XDocument xdoc = XDocument.Load("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=8&mkt=" + row["codigo"]);
					xdoc.Descendants("image").Select(p => new
					{
						vDataPublicacao = p.Element("startdate").Value,
						vUrl = p.Element("url").Value,
						vUrlBase = p.Element("urlBase").Value,
						vDescricao = p.Element("headline").Value + "<br>" + p.Element("copyright").Value
					}).ToList().ForEach(p =>
					{
						dgvResultado.Rows.Add(p.vDataPublicacao, p.vUrlBase, "", p.vUrl, p.vDescricao, "0");
					});
					xdoc = XDocument.Load("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=8&n=8&mkt=" + row["codigo"]);
					xdoc.Descendants("image").Select(p => new
					{
						vDataPublicacao = p.Element("startdate").Value,
						vUrl = p.Element("url").Value,
						vUrlBase = p.Element("urlBase").Value,
						vDescricao = p.Element("headline").Value + "<br>" + p.Element("copyright").Value
					}).ToList().ForEach(p =>
					{
						dgvResultado.Rows.Add(p.vDataPublicacao, p.vUrlBase, "", p.vUrl, p.vDescricao, "0");
					});
					dgvResultado.Rows.RemoveAt(8);
					string texto;
					int inicio; //"_", 2ª posição
					int fim;    //".", 2ª posição
					for (int j = 0; j < dgvResultado.Rows.Count; j++)
					{
						dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value = dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(6, 2) + "/" + dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(4, 2) + "/" + dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(0, 4);
						dgvResultado.Rows[j].Cells[dgcNomeArquivo.Index].Value = dgvResultado.Rows[j].Cells[dgcBase.Index].Value.ToString().Substring(11) + "_" + cboDimensoes.SelectedItem + ".jpg";
						texto = dgvResultado.Rows[j].Cells[dgcBase.Index].Value.ToString();
						inicio = texto.IndexOf('.', 0) + 1;
						fim = texto.IndexOf('_', 0);
						texto = texto.Substring(inicio, fim - inicio);
						dgvResultado.Rows[j].Cells[dgcBase.Index].Value = texto;
						texto = dgvResultado.Rows[j].Cells[dgcURL.Index].Value.ToString();
						inicio = texto.IndexOf('_', texto.IndexOf('_', 0) + 1);
						fim = texto.IndexOf('.', texto.IndexOf('.', 0) + 1);
						texto = texto.Replace(texto.Substring(inicio, fim - inicio), "_" + cboDimensoes.SelectedItem);
						dgvResultado.Rows[j].Cells[dgcURL.Index].Value = "http://www.bing.com" + texto;
					}
					//caminho completo da pasta do executável
					string filepath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
					DirectoryInfo d = new DirectoryInfo(filepath);
					for (int j = 0; j < dgvResultado.Rows.Count; j++)
					{
						foreach (FileInfo file in d.GetFiles("*.jpg"))
						{
							//nome da imagem sem extensão
							string path = Path.GetFileNameWithoutExtension(file.FullName);
							int k = path.IndexOf('_');
							if (k == -1) k = 0;
							//isola a base do nome da imagem
							string path2 = path.Substring(0, k);
							if (dgvResultado.Rows[j].Cells[dgcBase.Index].Value.ToString().Equals(path2))
							{
								dgvResultado.Rows[j].Cells[dgcStatus.Index].Value = "1";
								break;
							}
						}
					}
					for (int j = 0; j < dgvResultado.Rows.Count; j++)
					{
						if (Convert.ToInt32(dgvResultado.Rows[j].Cells[dgcStatus.Index].Value.ToString()).Equals(0))
						{
							if (dgvDisponibilidade.Rows.Count == 0)
							{
								dgvDisponibilidade.Rows.Add();
								row = _dtListaPaises.Rows[lsbPaises.SelectedIndex];
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcCodigo.Index].Value = row["codigo"].ToString();
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispPais.Index].Value = lsbPaises.SelectedItem;
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispDataPublicacao.Index].Value = dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value;
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispBase.Index].Value = dgvResultado.Rows[j].Cells[dgcBase.Index].Value;
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispNomeArquivo.Index].Value = dgvResultado.Rows[j].Cells[dgcNomeArquivo.Index].Value;
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispURL.Index].Value = dgvResultado.Rows[j].Cells[dgcURL.Index].Value;
								dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispDescricao.Index].Value = dgvResultado.Rows[j].Cells[dgcDescricao.Index].Value;
								contador += 1;
							}
							else
							{
								bool duplicado = false;
								for (int k = 0; k < dgvDisponibilidade.Rows.Count; k++)
								{
									if (dgvResultado.Rows[j].Cells[dgcBase.Index].Value.Equals(dgvDisponibilidade.Rows[k].Cells[dgcDispBase.Index].Value))
									{
										duplicado = true;
										break;
									}
								}
								if (duplicado == false)
								{
									dgvDisponibilidade.Rows.Add();
									row = _dtListaPaises.Rows[lsbPaises.SelectedIndex];
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcCodigo.Index].Value = row["codigo"].ToString();
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispPais.Index].Value = lsbPaises.SelectedItem;
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispDataPublicacao.Index].Value = dgvResultado.Rows[j].Cells[dgcDataPublicacao.Index].Value;
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispBase.Index].Value = dgvResultado.Rows[j].Cells[dgcBase.Index].Value;
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispNomeArquivo.Index].Value = dgvResultado.Rows[j].Cells[dgcNomeArquivo.Index].Value;
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispURL.Index].Value = dgvResultado.Rows[j].Cells[dgcURL.Index].Value;
									dgvDisponibilidade.Rows[dgvDisponibilidade.Rows.Count - 1].Cells[dgcDispDescricao.Index].Value = dgvResultado.Rows[j].Cells[dgcDescricao.Index].Value;
									contador += 1;
								}
							}
						}
					}
					if (rdbIdioma1.Checked)
					{
						tsslProcessamento.Text = _menuPortugues[15].Replace("XXX", (i + 1).ToString()).Replace("NNN", lsbPaises.Items.Count.ToString());
						switch (contador)
						{
							case 0:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", "NENHUMA IMAGEM ENCONTRADA");
								break;
							case 1:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMAGEM ENCONTRADA");
								break;
							default:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMAGENS ENCONTRADAS");
								break;
						}
					}
					if (rdbIdioma2.Checked)
					{
						tsslProcessamento.Text = _menuIngles[15].Replace("XXX", (i + 1).ToString()).Replace("NNN", lsbPaises.Items.Count.ToString());
						switch (contador)
						{
							case 0:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", "NO IMAGES FOUND");
								break;
							case 1:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMAGE FOUND");
								break;
							default:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMAGES FOUND");
								break;
						}
					}
					if (rdbIdioma3.Checked)
					{
						tsslProcessamento.Text = _menuEspanhol[15].Replace("XXX", (i + 1).ToString()).Replace("NNN", lsbPaises.Items.Count.ToString());
						switch (contador)
						{
							case 0:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", "NO SE ENCONTRARON IMÁGENES");
								break;
							case 1:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMAGEN ENCONTRADA");
								break;
							default:
								tsslProcessamento.Text = tsslProcessamento.Text.Replace("III", contador.ToString() + " IMÁGENES ENCONTRADAS");
								break;
						}
					}
					Application.DoEvents();
				}
				int modulo;
				for (i = 0; i <= dgvDisponibilidade.Rows.Count - 1; i++)
				{
					modulo = (int)Math.IEEERemainder(i, 2);
					if (modulo == 0)
					{
						if (i + 1 <= dgvDisponibilidade.Rows.Count - 1 && !dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.Equals(dgvDisponibilidade.Rows[i + 1].Cells[dgcDispPais.Index].Value))
						{
							dgvDisponibilidade.Rows.Insert(i + 1, dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.ToString());
							Application.DoEvents();
						}
						else if (i == dgvDisponibilidade.Rows.Count - 1)
						{
							dgvDisponibilidade.Rows.Insert(i + 1, dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.ToString());
							Application.DoEvents();
						}
					}
				}
				_codigoFonte = "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><title>TODAS AS IMAGENS DISPONÍVIES</title><style type=\"text/css\">section { border: dotted; width: 90%; margin-left: auto; margin-right: auto; padding-top: 5px; border-radius: 20px; display: inherit; } table { border-spacing: 2px; width: 100%; } caption { color: #33ccff; font-size: 50px; font-style: italic; font-weight: bold; } td { width: 50%; } div { height: 100px; border: 1px solid; padding: 5px; border-radius: 20px; display: inherit; } img { float: left; padding: 5px; } .azul { color: blue; } .vermelho { color: red; }</style></head><script type=\"text/javascript\">if (document.addEventListener) { document.addEventListener('contextmenu', function (e) { e.preventDefault(); }, false); } else { document.attachEvent('oncontextmenu', function () { window.event.returnValue = false; }); }</script><body>";
				string parSalvar = "";
				if (rdbIdioma1.Checked) parSalvar = _menuPortugues[14];
				if (rdbIdioma2.Checked) parSalvar = _menuIngles[14];
				if (rdbIdioma3.Checked) parSalvar = _menuEspanhol[14];
				for (i = 0; i < dgvDisponibilidade.Rows.Count; i++)
				{
					modulo = (int)Math.IEEERemainder(i, 2);
					var srcFlag = "";
					var nomeCidade = dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.ToString().ToUpper();
					var urlImagem = !string.IsNullOrEmpty((string)dgvDisponibilidade.Rows[i].Cells[dgcDispURL.Index].Value) ? dgvDisponibilidade.Rows[i].Cells[dgcDispURL.Index].Value.ToString() : "";
					var nomeArquivo = !string.IsNullOrEmpty((string)dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value) ? dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value.ToString() : "";
					var dataImagem = !string.IsNullOrEmpty((string)dgvDisponibilidade.Rows[i].Cells[dgcDispDataPublicacao.Index].Value) ? dgvDisponibilidade.Rows[i].Cells[dgcDispDataPublicacao.Index].Value.ToString() : "";
					var infoArquivo = (!string.IsNullOrEmpty(dataImagem) && !string.IsNullOrEmpty(nomeArquivo)) ? dataImagem + "<br>" + nomeArquivo : "";
					var descricaoArquivo = !string.IsNullOrEmpty((string)dgvDisponibilidade.Rows[i].Cells[dgcDispDescricao.Index].Value) ? dgvDisponibilidade.Rows[i].Cells[dgcDispDescricao.Index].Value.ToString() : "";
					if (modulo == 0)
					{
						if (i == 0 || !dgvDisponibilidade.Rows[i - 1].Cells[dgcDispPais.Index].Value
							.Equals(dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value))
						{
							_codigoFonte += "<section><table><caption><img src=\"" + srcFlag + "\" alt=" + nomeCidade + " height=\"40\">" + nomeCidade + "</caption><tr><td>";
							try
							{
								pcbTeste.Load(urlImagem);
								_codigoFonte += "<div><a href=\"" + urlImagem + "\" target=\"_blank\"><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \" oncontextmenu=\"window.external.LoadLine(" + i + ");\"></a>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								Application.DoEvents();
							}
							catch
							{
								pcbTeste.Image = null;
								if (!string.IsNullOrEmpty(urlImagem))
								{
									_codigoFonte += "<div><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \"><span class=\"vermelho\">[ LINK INDISPONÍVEL PARA DOWNLOAD ]</span><br>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								}
								else
								{
									_codigoFonte += "&nbsp;";
								}
							}
							_codigoFonte += "</td>";
						}
						else
						{
							_codigoFonte += "<tr><td>";
							try
							{
								pcbTeste.Load(urlImagem);
								_codigoFonte += "<div><a href=\"" + urlImagem + "\" target=\"_blank\"><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \" oncontextmenu=\"window.external.LoadLine(" + i + ");\"></a>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								Application.DoEvents();
							}
							catch
							{
								pcbTeste.Image = null;
								if (!string.IsNullOrEmpty(urlImagem))
								{
									_codigoFonte += "<div><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \"><span class=\"vermelho\">[ LINK INDISPONÍVEL PARA DOWNLOAD ]</span><br>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								}
								else
								{
									_codigoFonte += "&nbsp;";
								}
							}
							_codigoFonte += "</td>";
						}
					}
					else
					{
						if (dgvDisponibilidade.Rows[i - 1].Cells[dgcDispPais.Index].Value.Equals(dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value))
						{
							_codigoFonte += "<td>";
							try
							{
								pcbTeste.Load(urlImagem);
								_codigoFonte += "<div><a href=\"" + urlImagem + "\" target=\"_blank\"><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \" oncontextmenu=\"window.external.LoadLine(" + i + ");\"></a>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								Application.DoEvents();
							}
							catch
							{
								pcbTeste.Image = null;
								if (!string.IsNullOrEmpty(urlImagem))
								{
									_codigoFonte += "<div><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \"><span class=\"vermelho\">[ LINK INDISPONÍVEL PARA DOWNLOAD ]</span><br>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								}
								else
								{
									_codigoFonte += "&nbsp;";
								}
							}
							_codigoFonte += "</td></tr>";
							if ((i == dgvDisponibilidade.Rows.Count - 1) || (i + 1 < dgvDisponibilidade.Rows.Count - 1 && !dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.Equals(dgvDisponibilidade.Rows[i + 1].Cells[dgcDispPais.Index].Value)))
								_codigoFonte += "</table></section>";
						}
						else
						{
							_codigoFonte += "<td>&nbsp;</td></tr></table></section>";
							_codigoFonte += "<table><caption>" + nomeCidade + "</caption><tr><td>";
							try
							{
								pcbTeste.Load(urlImagem);
								_codigoFonte += "<div><a href=\"" + urlImagem + "\" target=\"_blank\"><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \" oncontextmenu=\"window.external.LoadLine(" + i + ");\"></a>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								Application.DoEvents();
							}
							catch
							{
								pcbTeste.Image = null;
								if (!string.IsNullOrEmpty(urlImagem))
								{
									_codigoFonte += "<div><img src=\"" + urlImagem + "\" alt=\" " + dataImagem + " \" height=\"90\" title=\" [ " + parSalvar + " ] \"><span class=\"vermelho\">[ LINK INDISPONÍVEL PARA DOWNLOAD ]</span><br>" + infoArquivo + "<br>" + descricaoArquivo + "</div>";
								}
								else
								{
									_codigoFonte += "&nbsp;";
								}
							}
							_codigoFonte += "</td>";
							if (i == dgvDisponibilidade.Rows.Count - 1 || !dgvDisponibilidade.Rows[i].Cells[dgcDispPais.Index].Value.Equals(dgvDisponibilidade.Rows[i + 1].Cells[dgcDispPais.Index].Value))
								_codigoFonte += "<td>&nbsp;</td></tr></table></section>";
						}
					}
				}
				//_codigoFonte += (contador > 0) ? "<section>LEGENDA:<br><span class=\"azul\">Imagens não baixadas</span><br><span class=\"vermelho\">Imagens já baixadas</span></section>" : "<span class=\"vermelho\">NÃO HÁ IMAGENS DISPONÍVEIS PARA DOWNLOAD</span>";
				_codigoFonte += (contador > 0) ? "" : "<span class=\"vermelho\">NÃO HÁ IMAGENS DISPONÍVEIS PARA DOWNLOAD</span>";
				_codigoFonte += "</body></html>".Replace("\"<br>", "\"").Replace("<br><br>", "<br>");
				if (rdbIdioma1.Checked)
				{
					switch (contador)
					{
						case 0:
							tsslProcessamento.Text = _menuPortugues[16].Replace("III", "NENHUMA IMAGEM DISPONÍVEL");
							break;
						case 1:
							tsslProcessamento.Text = _menuPortugues[16].Replace("III", contador.ToString() + " IMAGEM DISPONÍVEL");
							break;
						default:
							tsslProcessamento.Text = _menuPortugues[16].Replace("III", contador.ToString() + " IMAGENS DISPONÍVEIS");
							break;
					}
				}
				if (rdbIdioma2.Checked)
				{
					switch (contador)
					{
						case 0:
							tsslProcessamento.Text = _menuIngles[16].Replace("III", "NO IMAGES AVAILABLE");
							break;
						case 1:
							tsslProcessamento.Text = _menuIngles[16].Replace("III", contador.ToString() + " IMAGE AVAILABLE");
							break;
						default:
							tsslProcessamento.Text = _menuIngles[16].Replace("III", contador.ToString() + " AVAILABLE IMAGES");
							break;
					}
				}
				if (rdbIdioma3.Checked)
				{
					switch (contador)
					{
						case 0:
							tsslProcessamento.Text = _menuEspanhol[16].Replace("III", "NO HAY IMÁGENES DISPONIBLES");
							break;
						case 1:
							tsslProcessamento.Text = _menuEspanhol[16].Replace("III", contador.ToString() + " IMAGEN DISPONIBLE");
							break;
						default:
							tsslProcessamento.Text = _menuEspanhol[16].Replace("III", contador.ToString() + " IMÁGENES DISPONIBLES");
							break;
					}
				}
				cmdSaveAll.Enabled = contador > 0;
			}
			else
			{
				tsslProcessamento.Text = "";
				row = _dtListaPaises.Rows[lsbPaises.SelectedIndex];
				string pais = row["codigo"].ToString().Substring(row["codigo"].ToString().Length - 2,2);
				string caminho = Application.StartupPath + "\\Flags\\" + pais + ".svg"; //Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
				_codigoFonte = (rdbLayout1.Checked) ? Resources.layout1 : Resources.layout2;
				_codigoFonte = _codigoFonte.Replace("srcFlag", caminho)
					.Replace("nomeCidade", lsbPaises.SelectedItem.ToString().ToUpper())
					.Replace("urlImagem01", dgvResultado.Rows[0].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo01", dgvResultado.Rows[0].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem01", dgvResultado.Rows[0].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo01", dgvResultado.Rows[0].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[0].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo01", dgvResultado.Rows[0].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem02", dgvResultado.Rows[1].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo02", dgvResultado.Rows[1].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem02", dgvResultado.Rows[1].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo02", dgvResultado.Rows[1].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[1].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo02", dgvResultado.Rows[1].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem03", dgvResultado.Rows[2].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo03", dgvResultado.Rows[2].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem03", dgvResultado.Rows[2].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo03", dgvResultado.Rows[2].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[2].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo03", dgvResultado.Rows[2].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem04", dgvResultado.Rows[3].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo04", dgvResultado.Rows[3].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem04", dgvResultado.Rows[3].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo04", dgvResultado.Rows[3].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[3].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo04", dgvResultado.Rows[3].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem05", dgvResultado.Rows[4].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo05", dgvResultado.Rows[4].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem05", dgvResultado.Rows[4].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo05", dgvResultado.Rows[4].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[4].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo05", dgvResultado.Rows[4].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem06", dgvResultado.Rows[5].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo06", dgvResultado.Rows[5].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem06", dgvResultado.Rows[5].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo06", dgvResultado.Rows[5].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[5].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo06", dgvResultado.Rows[5].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem07", dgvResultado.Rows[6].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo07", dgvResultado.Rows[6].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem07", dgvResultado.Rows[6].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo07", dgvResultado.Rows[6].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[6].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo07", dgvResultado.Rows[6].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem08", dgvResultado.Rows[7].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo08", dgvResultado.Rows[7].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem08", dgvResultado.Rows[7].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo08", dgvResultado.Rows[7].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[7].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo08", dgvResultado.Rows[7].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem09", dgvResultado.Rows[8].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo09", dgvResultado.Rows[8].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem09", dgvResultado.Rows[8].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo09", dgvResultado.Rows[8].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[8].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo09", dgvResultado.Rows[8].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem10", dgvResultado.Rows[9].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo10", dgvResultado.Rows[9].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem10", dgvResultado.Rows[9].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo10", dgvResultado.Rows[9].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[9].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo10", dgvResultado.Rows[9].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem11", dgvResultado.Rows[10].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo11", dgvResultado.Rows[10].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem11", dgvResultado.Rows[10].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo11", dgvResultado.Rows[10].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[10].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo11", dgvResultado.Rows[10].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem12", dgvResultado.Rows[11].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo12", dgvResultado.Rows[11].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem12", dgvResultado.Rows[11].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo12", dgvResultado.Rows[11].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[11].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo12", dgvResultado.Rows[11].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem13", dgvResultado.Rows[12].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo13", dgvResultado.Rows[12].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem13", dgvResultado.Rows[12].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo13", dgvResultado.Rows[12].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[12].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo13", dgvResultado.Rows[12].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem14", dgvResultado.Rows[13].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo14", dgvResultado.Rows[13].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem14", dgvResultado.Rows[13].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo14", dgvResultado.Rows[13].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[13].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo14", dgvResultado.Rows[13].Cells[dgcDescricao.Index].Value.ToString())
					.Replace("urlImagem15", dgvResultado.Rows[14].Cells[dgcURL.Index].Value.ToString())
					.Replace("nomeArquivo15", dgvResultado.Rows[14].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("dataImagem15", dgvResultado.Rows[14].Cells[dgcDataPublicacao.Index].Value.ToString())
					.Replace("infoArquivo15", dgvResultado.Rows[14].Cells[dgcDataPublicacao.Index].Value.ToString() + "<br>" + dgvResultado.Rows[14].Cells[dgcNomeArquivo.Index].Value.ToString())
					.Replace("descricaoArquivo15", dgvResultado.Rows[14].Cells[dgcDescricao.Index].Value.ToString());
				if (rdbIdioma1.Checked) _codigoFonte = _codigoFonte.Replace("parSalvar", _menuPortugues[14]);
				if (rdbIdioma2.Checked) _codigoFonte = _codigoFonte.Replace("parSalvar", _menuIngles[14]);
				if (rdbIdioma3.Checked) _codigoFonte = _codigoFonte.Replace("parSalvar", _menuEspanhol[16]);
				if (Convert.ToInt32(dgvResultado.Rows[0].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor01", "red"); else _codigoFonte = _codigoFonte.Replace("cor01", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[1].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor02", "red"); else _codigoFonte = _codigoFonte.Replace("cor02", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[2].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor03", "red"); else _codigoFonte = _codigoFonte.Replace("cor03", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[3].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor04", "red"); else _codigoFonte = _codigoFonte.Replace("cor04", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[4].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor05", "red"); else _codigoFonte = _codigoFonte.Replace("cor05", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[5].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor06", "red"); else _codigoFonte = _codigoFonte.Replace("cor06", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[6].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor07", "red"); else _codigoFonte = _codigoFonte.Replace("cor07", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[7].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor08", "red"); else _codigoFonte = _codigoFonte.Replace("cor08", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[8].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor09", "red"); else _codigoFonte = _codigoFonte.Replace("cor09", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[9].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor10", "red"); else _codigoFonte = _codigoFonte.Replace("cor10", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[10].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor11", "red"); else _codigoFonte = _codigoFonte.Replace("cor11", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[11].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor12", "red"); else _codigoFonte = _codigoFonte.Replace("cor12", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[12].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor13", "red"); else _codigoFonte = _codigoFonte.Replace("cor13", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[13].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor14", "red"); else _codigoFonte = _codigoFonte.Replace("cor14", "blue");
				if (Convert.ToInt32(dgvResultado.Rows[14].Cells[dgcStatus.Index].Value.ToString()).Equals(1)) _codigoFonte = _codigoFonte.Replace("cor15", "red"); else _codigoFonte = _codigoFonte.Replace("cor15", "blue");
			}
			_codigoFonte = _codigoFonte.Replace("\"<br>", "\"").Replace("<br><br>", "<br>");
			wbbResultado.DocumentText = _codigoFonte;
			for (i = 0; i < dgvResultado.Rows.Count; i++)
			{
				if (Convert.ToInt16(dgvResultado.Rows[i].Cells[dgcStatus.Index].Value.ToString()).Equals(0))
				{
					cmdSaveAll.Enabled = true;
					return;
				}
			}
			Cursor = Cursors.Default;
		}

		private void CarregarLista()
		{
			_dtListaPaises = new DataTable();
			_dtListaPaises.Columns.Add("codigo", typeof(string));
			_dtListaPaises.Columns.Add("portugues", typeof(string));
			_dtListaPaises.Columns.Add("ingles", typeof(string));
			_dtListaPaises.Columns.Add("espanhol", typeof(string));
			XDocument xdoc = XDocument.Load(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\lista_paises_bing.xml");
			xdoc.Descendants("lista_paises_bing").Select(p => new
			{
				vCodigo = p.Element("codigo").Value,
				vPortugues = p.Element("portugues").Value,
				vIngles = p.Element("ingles").Value,
				vEspanhol = p.Element("espanhol").Value
			}).ToList().ForEach(p =>
			{
				_dtListaPaises.Rows.Add(p.vCodigo, p.vPortugues, p.vIngles, p.vEspanhol);
			});
		}

		private void LimparGrade()
		{
			wbbResultado.DocumentText = "";
			cmdSaveAll.Enabled = false;
			dgvResultado.Rows.Clear();
			tsslProcessamento.Text = "";
		}

		public FormBing()
		{
			if (!IsConnected())
			{
				MessageBox.Show("UMA CONEXÃO COM A INTERNET DEVE ESTAR ATIVA.\r\nFAVOR VERIFICAR.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Environment.Exit(0);
				return;
			}
			InitializeComponent();
			// Set the WebBrowser to use an instance of the ScriptManager to handle method calls to C#.
			wbbResultado.ObjectForScripting = new ScriptManager(this);
			LimparGrade();
			CarregarLista();
			RdbIdioma2_CheckedChanged(null, null);
			tsslProcessamento.Text = "";
			CboDimensoes_Click(null, null);
		}

		private void FormBing_MouseDown(object sender, MouseEventArgs e)
		{
			//Screen s = Screen.FromControl(this);
			//int i = 14;
			////MessageBox.Show(s.Primary.ToString() + "\r\n" + s.Bounds.Width + "x" + s.Bounds.Height);
			//string resolucao = s.Bounds.Width + "x" + s.Bounds.Height;
			//for (int j = 0; j < cboDimensoes.Items.Count; j++)
			//{
			//	if ((string)cboDimensoes.Items[j] == resolucao)
			//	{
			//		i = j;
			//		break;
			//	}
			//}
			//cboDimensoes.SelectedIndex = i;
		}

		private void CboDimensoes_Click(object sender, EventArgs e)
		{
			int i = cboDimensoes.SelectedIndex;
			if (cboDimensoes.SelectedIndex == -1) i = 14;
			cboDimensoes.Items.Clear();
			cboDimensoes.Items.Add("150x150");
			cboDimensoes.Items.Add("240x320");
			cboDimensoes.Items.Add("320x240");
			cboDimensoes.Items.Add("480x640");
			cboDimensoes.Items.Add("480x800");
			cboDimensoes.Items.Add("640x480");
			cboDimensoes.Items.Add("720x1280");
			cboDimensoes.Items.Add("800x480");
			cboDimensoes.Items.Add("800x600");
			cboDimensoes.Items.Add("1024x768");
			cboDimensoes.Items.Add("1080x1920");
			cboDimensoes.Items.Add("1280x720");
			cboDimensoes.Items.Add("1366x768");
			cboDimensoes.Items.Add("1600x900");
			cboDimensoes.Items.Add("1920x1080");
			cboDimensoes.Items.Add("1920x1200");
			//Screen s = Screen.FromControl(this);
			////MessageBox.Show(s.Primary.ToString() + "\r\n" + s.Bounds.Width + "x" + s.Bounds.Height);
			//string resolucao = s.Bounds.Width + "x" + s.Bounds.Height;
			//for (int j = 0; j < cboDimensoes.Items.Count; j++)
			//{
			//	if ((string)cboDimensoes.Items[j] == resolucao)
			//	{
			//		i = j;
			//		break;
			//	}
			//}
			cboDimensoes.SelectedIndex = i;
		}

		private void CmdCidadeAnt_Click(object sender, EventArgs e)
		{
			int i = lsbPaises.SelectedIndex - 1;
			i = (i < 0) ? 0 : i;
			lsbPaises.SelectedIndex = i;
			LsbPaises_Click(null, null);
		}

		private void CmdCidadeSeg_Click(object sender, EventArgs e)
		{
			int i = lsbPaises.SelectedIndex;
			i = (i < 0) ? 0 : i + 1;
			if (i >= lsbPaises.Items.Count) i = lsbPaises.Items.Count - 1;
			lsbPaises.SelectedIndex = i;
			LsbPaises_Click(null, null);
		}

		private void CmdSaveAll_Click(object sender, EventArgs e)
		{
			WebClient cliente = new WebClient();
			if (rdbLayout3.Checked)
			{
				if (dgvDisponibilidade.Rows.Count == 0) return;
				Cursor = Cursors.WaitCursor;
				for (int i = 0; i < dgvDisponibilidade.Rows.Count; i++)
				{
					if (!string.IsNullOrEmpty((string)dgvDisponibilidade.Rows[i].Cells[dgcDispURL.Index].Value))
					{
						try
						{
							cliente.DownloadFile(dgvDisponibilidade.Rows[i].Cells[dgcDispURL.Index].Value.ToString(), dgvDisponibilidade.Rows[i].Cells[dgcDispNomeArquivo.Index].Value.ToString());
						}
						catch { }
					}
				}
				Cursor = Cursors.Default;
			}
			else
			{
				if (dgvResultado.Rows.Count == 0) return;
				Cursor = Cursors.WaitCursor;
				for (int i = 0; i < dgvResultado.Rows.Count; i++)
				{
					if (Convert.ToInt32(dgvResultado.Rows[i].Cells[dgcStatus.Index].Value.ToString()).Equals(0))
					{
						try
						{
							cliente.DownloadFile(dgvResultado.Rows[i].Cells[dgcURL.Index].Value.ToString(), dgvResultado.Rows[i].Cells[dgcNomeArquivo.Index].Value.ToString());
						}
						catch { }
					}
				}
				Cursor = Cursors.Default;
			}
		}

		private void LsbPaises_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			LimparGrade();
			if (lsbPaises.SelectedIndex == -1) lsbPaises.SelectedIndex = 0;
			DataRow row = _dtListaPaises.Rows[lsbPaises.SelectedIndex];
			XDocument xdoc = XDocument.Load("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=8&mkt=" + row["codigo"]);
			xdoc.Descendants("image").Select(p => new
			{
				vDataPublicacao = p.Element("startdate").Value,
				vUrl = p.Element("url").Value,
				vUrlBase = p.Element("urlBase").Value,
				vDescricao = p.Element("headline").Value + "<br>" + p.Element("copyright").Value
			}).ToList().ForEach(p =>
			{
				dgvResultado.Rows.Add(p.vDataPublicacao, p.vUrlBase, "", p.vUrl, p.vDescricao, "0");
			});
			xdoc = XDocument.Load("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=8&n=8&mkt=" + row["codigo"]);
			xdoc.Descendants("image").Select(p => new
			{
				vDataPublicacao = p.Element("startdate").Value,
				vUrl = p.Element("url").Value,
				vUrlBase = p.Element("urlBase").Value,
				vDescricao = p.Element("headline").Value + "<br>" + p.Element("copyright").Value
			}).ToList().ForEach(p =>
			{
				dgvResultado.Rows.Add(p.vDataPublicacao, p.vUrlBase, "", p.vUrl, p.vDescricao, "0");
			});
			dgvResultado.Rows.RemoveAt(8);
			for (int i = 0; i < dgvResultado.Rows.Count; i++)
			{
				dgvResultado.Rows[i].Cells[dgcDataPublicacao.Index].Value = dgvResultado.Rows[i].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(6, 2) + "/" + dgvResultado.Rows[i].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(4, 2) + "/" + dgvResultado.Rows[i].Cells[dgcDataPublicacao.Index].Value.ToString().Substring(0, 4);
				dgvResultado.Rows[i].Cells[dgcNomeArquivo.Index].Value = dgvResultado.Rows[i].Cells[dgcBase.Index].Value.ToString().Substring(11) + "_" + cboDimensoes.SelectedItem + ".jpg";
				var texto = dgvResultado.Rows[i].Cells[dgcBase.Index].Value.ToString();
				var inicio = texto.IndexOf('.', 0) + 1; //"_", 2ª posição
				var fim = texto.IndexOf('_', 0);    //".", 2ª posição
				texto = texto.Substring(inicio, fim - inicio);
				dgvResultado.Rows[i].Cells[dgcBase.Index].Value = texto;
				texto = dgvResultado.Rows[i].Cells[dgcURL.Index].Value.ToString();
				inicio = texto.IndexOf('_', texto.IndexOf('_', 0) + 1);
				fim = texto.IndexOf('.', texto.IndexOf('.', 0) + 1);
				texto = texto.Replace(texto.Substring(inicio, fim - inicio), "_" + cboDimensoes.SelectedItem);
				dgvResultado.Rows[i].Cells[dgcURL.Index].Value = "http://www.bing.com" + texto;
			}
			//caminho completo da pasta do executável
			string filepath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			DirectoryInfo d = new DirectoryInfo(filepath);
			for (int i = 0; i < dgvResultado.Rows.Count; i++)
			{
				foreach (FileInfo file in d.GetFiles("*.jpg"))
				{
					//nome da imagem sem extensão
					string path = Path.GetFileNameWithoutExtension(file.FullName);
					int j = path.IndexOf('_');
					if (j == -1) j = 0;
					//isola a base do nome da imagem
					string path2 = path.Substring(0, j);
					if (dgvResultado.Rows[i].Cells[dgcBase.Index].Value.ToString().Equals(path2))
					{
						dgvResultado.Rows[i].Cells[dgcStatus.Index].Value = "1";
						break;
					}
				}
			}
			CarregarHTML();
			Cursor = Cursors.Default;
		}

		private void RdbIdioma1_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbIdioma1.Checked)
			{
				grbIdioma.Text = _menuPortugues[0];
				rdbIdioma1.Text = _menuPortugues[1];
				rdbIdioma2.Text = _menuPortugues[2];
				rdbIdioma3.Text = _menuPortugues[3];
				grbPaises.Text = _menuPortugues[4];
				grbDimensoes.Text = _menuPortugues[5];
				grbLayout.Text = _menuPortugues[6];
				rdbLayout1.Text = _menuPortugues[7];
				rdbLayout2.Text = _menuPortugues[8];
				rdbLayout3.Text = _menuPortugues[9];
				grbNavegacao.Text = _menuPortugues[10];
				cmdCidadeAnt.Text = _menuPortugues[11];
				cmdCidadeSeg.Text = _menuPortugues[12];
				cmdSaveAll.Text = _menuPortugues[13];
				lsbPaises.Items.Clear();
				_dvListaPaises = _dtListaPaises.DefaultView;
				_dvListaPaises.Sort = "portugues";
				_dtListaPaises = _dvListaPaises.ToTable();
				foreach (DataRow row in _dtListaPaises.Rows)
				{
					lsbPaises.Items.Add(row["portugues"].ToString());
				}
			}
		}

		private void RdbIdioma2_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbIdioma2.Checked)
			{
				grbIdioma.Text = _menuIngles[0];
				rdbIdioma1.Text = _menuIngles[1];
				rdbIdioma2.Text = _menuIngles[2];
				rdbIdioma3.Text = _menuIngles[3];
				grbPaises.Text = _menuIngles[4];
				grbDimensoes.Text = _menuIngles[5];
				grbLayout.Text = _menuIngles[6];
				rdbLayout1.Text = _menuIngles[7];
				rdbLayout2.Text = _menuIngles[8];
				rdbLayout3.Text = _menuIngles[9];
				grbNavegacao.Text = _menuIngles[10];
				cmdCidadeAnt.Text = _menuIngles[11];
				cmdCidadeSeg.Text = _menuIngles[12];
				cmdSaveAll.Text = _menuIngles[13];
				lsbPaises.Items.Clear();
				_dvListaPaises = _dtListaPaises.DefaultView;
				_dvListaPaises.Sort = "ingles";
				_dtListaPaises = _dvListaPaises.ToTable();
				foreach (DataRow row in _dtListaPaises.Rows)
				{
					lsbPaises.Items.Add(row["ingles"].ToString());
				}

			}
		}

		private void RdbIdioma3_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbIdioma3.Checked)
			{
				grbIdioma.Text = _menuEspanhol[0];
				rdbIdioma1.Text = _menuEspanhol[1];
				rdbIdioma2.Text = _menuEspanhol[2];
				rdbIdioma3.Text = _menuEspanhol[3];
				grbPaises.Text = _menuEspanhol[4];
				grbDimensoes.Text = _menuEspanhol[5];
				grbLayout.Text = _menuEspanhol[6];
				rdbLayout1.Text = _menuEspanhol[7];
				rdbLayout2.Text = _menuEspanhol[8];
				rdbLayout3.Text = _menuEspanhol[9];
				grbNavegacao.Text = _menuEspanhol[10];
				cmdCidadeAnt.Text = _menuEspanhol[11];
				cmdCidadeSeg.Text = _menuEspanhol[12];
				cmdSaveAll.Text = _menuEspanhol[13];
				lsbPaises.Items.Clear();
				_dvListaPaises = _dtListaPaises.DefaultView;
				_dvListaPaises.Sort = "espanhol";
				_dtListaPaises = _dvListaPaises.ToTable();
				foreach (DataRow row in _dtListaPaises.Rows)
				{
					lsbPaises.Items.Add(row["espanhol"].ToString());
				}
			}
		}

		private void RdbLayout1_Click(object sender, EventArgs e)
		{
			lsbPaises.SelectedItem = lsbPaises.SelectedIndex;
			lsbPaises.TopIndex = lsbPaises.SelectedIndex;
			LsbPaises_Click(null, null);
		}

		private void RdbLayout2_Click(object sender, EventArgs e)
		{
			lsbPaises.SelectedItem = lsbPaises.SelectedIndex;
			lsbPaises.TopIndex = lsbPaises.SelectedIndex;
			LsbPaises_Click(null, null);
		}

		private void RdbLayout3_Click(object sender, EventArgs e)
		{
			lsbPaises.SelectedItem = lsbPaises.SelectedIndex;
			lsbPaises.TopIndex = lsbPaises.SelectedIndex;
			LsbPaises_Click(null, null);
		}
	}
}
