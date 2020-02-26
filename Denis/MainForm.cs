/*
 * Criado por SharpDevelop.
 * Usuário: Denis
 * Data: 7/6/2010
 * Hora: 0:14
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Denis
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		// This point keeps track of the empty point where there is no button
			// a place where a button move can be made
			EmptyPoint = new Point ();
			
			// Create a ArrayList alAllButtons to store the buttons
			alAllButtons = new ArrayList ();
			// Add all the buttons present on the panel to the ArrayList
			foreach(Button b in panel1.Controls )
				alAllButtons.Add (b);

			// Try loading the Default picture from the default path
			try
			{
				MainBitmap = (Bitmap)Bitmap.FromFile (Application.StartupPath +"\\game.jpg");
				MessageBox.Show (Application.StartupPath.ToString ()); 
			}
			catch (Exception ex)
			{
				// If there is an error then display the error message.
				MessageBox.Show (ex.Message.ToString ());
			}

			// Initialize Empty Point to the down right most corner of the panel
			Point p = new Point (320,320);
			EmptyPoint.X = 240;
			EmptyPoint.Y = 240;

			// Initialize the Game Mode to the Picture Mode
			miFileModeNumber.Checked = false;
			miFileModePicture.Checked = true;
			miFileModeNumPic.Checked = false;
			HideNumbersFromButtons();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
				
		// This is the function which moves the button to the Empty places
		// This function takes a button as a parameter
		private void MoveButton(Button ClickedButton )
		{
		
			// Proceed with	the	function only if the button	is either horizontally or
			// vertically inline with the Empty	Point			
			if(EmptyPoint.X	== ClickedButton.Location.X	|| EmptyPoint.Y	== ClickedButton.Location.Y)
			{
				// After the button	will be	moved the new Empty	Point is gonna change
				// So store	the	current	position of	the	Button in a	tempPoint
				Point tempEmptyPoint =	new	Point ();
				tempEmptyPoint = ClickedButton.Location;

				// Find out in which direction we have to move the Button
				int	d =	Direction (ClickedButton.Location ,EmptyPoint);

				// Follow this procedure if we have to move the button Up or Down
				// i.e. the button is vertically inline with the Empty Point
				if(EmptyPoint.X	== ClickedButton.Location.X	)
				{
					// There could be some other buttons that are in b/w the clicked
					// button and the EmptyPoint. So we'll have to shift all the buttons
					foreach(Button bx in panel1.Controls )
					{
						if (((bx.Location.Y	>= ClickedButton.Location.Y) 
							&& (bx.Location.Y <	EmptyPoint.Y ) &&(bx.Location.X	== EmptyPoint.X	)) || ((bx.Location.Y <= ClickedButton.Location.Y) 
							&& (bx.Location.Y >	EmptyPoint.Y )&&(bx.Location.X == EmptyPoint.X )))
						{
							switch (d)
							{
								case 1:	Functions.MoveUp(bx);
									break;
								case 3:	Functions.MoveDown(bx);
									break;
							}
						}
				
					}
				}

				// Follow this procedure if we have to move the button Left or Right
				// i.e. the Clicked button is horizontally inline with the Empty Space
				if(EmptyPoint.Y	== ClickedButton.Location.Y	)
				{
					// There could be some other buttons that are in b/w the clicked
					// button and the EmptyPoint. So we'll have to shift all the buttons
					foreach(Button bx in panel1.Controls )
					{
						if (((bx.Location.X	>= ClickedButton.Location.X) 
							&& (bx.Location.X <	EmptyPoint.X ) && (bx.Location.Y ==	EmptyPoint.Y  )) ||	((bx.Location.X	<= ClickedButton.Location.X) 
							&& (bx.Location.X >EmptyPoint.X	) && (bx.Location.Y	== EmptyPoint.Y	 )))
						{
							switch (d)
							{
								case 0 : Functions.MoveRight(bx);
									break;
								case 2:	Functions.MoveLeft(bx);
									break;
									
							}

						}
					}
				}
				
			EmptyPoint = tempEmptyPoint;	
		}
		}
				private void OnButtonClick(object sender, System.EventArgs e)
		{		
			MoveButton((Button)sender);
		}
		
		

	}
}
