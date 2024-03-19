#pragma once
#include "SDL.h"
#include "SDL_syswm.h"
#include "Windows.h"
#include "iostream"
#include "thread"
#include "SDL_image.h"



namespace SdlonWindoesTest2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;



	/// <summary>
	/// Summary for MainForm
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{

	


	public:



		

		SDL_Window* window;
	private: System::Windows::Forms::Timer^ timer1;
	private: System::Windows::Forms::Button^ button1;

		   int mousePositionOx;
		   int mousePositionOy;
		

		   int current_mousepositionx;
		   int current_mousepositiony;

	public:
		SDL_Renderer* renderer;
		MainForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			//createSecondWindow();

		/*	
			MyClass myObject;
			std::thread t(&MyClass::RunInThread, &myObject);*/


			createSecondWindow();

		
			//timer1->Start();


			//HWND hwndFound = FindWindow(NULL, TEXT("panel1"));

			//SetWindowLongPtr(hwndFound, GWLP_WNDPROC, reinterpret_cast<LONG_PTR>("MyWndProc"));

			//panel1->Refresh();

			//HWND hWndPictureBox = static_cast<HWND>(panel1->Handle.ToPointer());

			//HWND calcHwnd = FindWindow(L"Mi Ventana", NULL);
			//if (calcHwnd != NULL)
			//{
			//	// Change the parent so the calc window belongs to our apps main window 
			//	SetParent(calcHwnd, hWndPictureBox);

			//	// Update the style so the calc window is embedded in our main window
			//	SetWindowLong(calcHwnd, GWL_STYLE, GetWindowLong(calcHwnd, GWL_STYLE) | WS_CHILD);

			//	// We need to update the position as well since changing the parent does not
			//	// adjust it automatically.
			//	SetWindowPos(calcHwnd, NULL, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
			//}

		}


		void EmbedCalc(HWND Parent, HWND Son)
		{
			//HWND Son = FindWindow(L"CalcFrame", NULL);
			if (Son != NULL)
			{
				// Change the parent so the calc window belongs to our apps main window 
				SetParent(Son, Parent);

				// Update the style so the calc window is embedded in our main window
				//SetWindowLong(Son, GWL_STYLE, GetWindowLong(Son, GWL_STYLE) | WS_CHILD);

				// We need to update the position as well since changing the parent does not
				// adjust it automatically.
				SetWindowPos(Son, NULL, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
			}
		}
		
	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}

		void miHilo() {
			std::cout << "Hola desde el hilo" << std::endl;
		}
	

		void createSecondWindow()
		{
			HWND hWndPictureBox = static_cast<HWND>(panel1->Handle.ToPointer());
			if (SDL_Init(SDL_INIT_VIDEO) < 0) {

			}


			//SDL_SetHint(SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT, "%p");

			 window = SDL_CreateWindow("Mi Ventana", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, panel1->Width, panel1->Height, SDL_WINDOW_BORDERLESS);
			

			


			SDL_Init(SDL_INIT_VIDEO);
			IMG_Init(IMG_INIT_PNG);
			//SDL_Window* window =  SDL_CreateWindowFrom(hWndPictureBox);

			//SDL_SetHint(SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT, "%p", window);

			SDL_SysWMinfo wmInfo;
			SDL_GetWindowWMInfo(window, &wmInfo);
			HWND hwnd = wmInfo.info.win.window;
			EmbedCalc(hWndPictureBox, hwnd);


			
			 renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
			//
			//int x1 = 100;
			//int y1 = 200;
			//int x2 = panel1->Width;
			//int y2 = panel1->Height;

			//SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255); // Color rojo
			//SDL_RenderDrawLine(renderer, x1, y1, x2, y2);

			//// Muestra la línea en la ventana
			//SDL_RenderPresent(renderer);

			//panel1->Refresh();

			
			//SDL_RenderCopy(renderer, image, , IntPtr.Zero);
				
			//	
		
	
		//	switch (info.subsystem) {
		//	case SDL_SYSWM_WINDOWS:
		//		 S= 1;
		//		
		//		// Accede a info.info.win.window para obtener el HWND nativo
		//		break;
		//	case SDL_SYSWM_X11:
		//		S = 1;
		//		// Accede a info.info.x11.window para obtener el identificador de ventana nativo
		//		break;
		//		S = 1;
		//		// Agrega más casos para otros sistemas si es necesario
		//	default:
		//	
		//		break;
		//	}

		/*	SDL_DestroyWindow(window);
			SDL_Quit();*/
		}

	

		DWORD WINAPI thread1(__in LPVOID lpParameter) {
			while (1) {
				Render();
			}

		}

		void Myevents()
		{
			SDL_Event evento;
			SDL_PollEvent(&evento);


			
			switch (evento.type) 
			{
				case SDL_QUIT:
				
					break;
				case SDL_MOUSEBUTTONDOWN:
					if (evento.button.button == SDL_BUTTON_LEFT) 
					{
						int x, y;
						Uint32 buttons = SDL_GetMouseState(&x, &y);
						mousePositionOx = x;
						mousePositionOy = y;

					}
					break;
				
			}

			int x1, y2;
			Uint32 buttons = SDL_GetMouseState(&x1, &y2);
			current_mousepositionx = x1;
			current_mousepositiony = y2;
		}

		void Render()
		{
			// Sets the color that the screen will be cleared with.
	
			SDL_SetRenderDrawColor(renderer, 135, 206, 235, 255);

			// Clears the current render surface.
			SDL_RenderClear(renderer);

			// Set the color to red before drawing our shape
			SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

			//Random rnd = new Random();
			//int randomNumber = rnd.Next();

			//// Draw a line from top left to bottom right

			SDL_RenderDrawLine(renderer, mousePositionOx, mousePositionOy, current_mousepositionx, current_mousepositiony);
			
			//SDL_Surface* image = load_image("C:/Users/schal/source/repos/SdlonWindoesTest2/x64/Debug/2.png");

			SDL_Surface* image = SDL_CreateRGBSurface(0, 800, 600, 32, 0xFF000000, 0x00FF0000, 0x0000FF00, 0x000000FF);

			string s = IMG_GetError();
			SDL_Texture* imageTexture = SDL_CreateTextureFromSurface(renderer, image);



			//SDL_Texture* imageTexture =  SDL_CreateTexture(renderer, SDL_PIXELFORMAT_RGBA32, SDL_TEXTUREACCESS_STREAMING, panel1->Width, panel1->Height);
			
			SDL_RenderCopy(renderer, imageTexture, NULL, NULL);



			//int numeroAleatorio = std::rand() % 640 + 1;

			//SDL_RenderDrawLine(renderer, 0, 0, numeroAleatorio, 480);

			//// Switches out the currently presented render surface with the one we just did work on.
		

			/*SDL_Surface* superficiePNG = SDL_CreateRGBSurface(0, image->w, image->h, 32, 0xFF000000, 0x00FF0000, 0x0000FF00, 0x000000FF);
			SDL_BlitSurface(image, nullptr, superficiePNG, nullptr);*/


			/*IMG_SavePNG(superficiePNG, "mi_imagen_renderizada.png");
			SDL_FreeSurface(superficiePNG);*/

			SDL_RenderPresent(renderer);
			// Guarda la superficie como un archivo PNG
			


			/* SDL_Surface* superficieInfo = SDL_GetWindowSurface(window);
			 save_image("C:/Users/schal/source/repos/SdlonWindoesTest2/x64/Debug/2out.png",  superficieInfo);*/





		}

		void save_image(std::string filename, SDL_Surface* superficieInfo)
		{

			
			if (superficieInfo == nullptr) {
			}


			unsigned char* pixeles = new (std::nothrow) unsigned char[superficieInfo->w * superficieInfo->h * superficieInfo->format->BytesPerPixel];
			if (pixeles == nullptr) {

			}

			if (SDL_RenderReadPixels(renderer, &superficieInfo->clip_rect, superficieInfo->format->format, pixeles, superficieInfo->w * superficieInfo->format->BytesPerPixel) != 0) {

			}

			SDL_Surface* superficieGuardada = SDL_CreateRGBSurfaceFrom(pixeles, superficieInfo->w, superficieInfo->h, superficieInfo->format->BitsPerPixel,
				superficieInfo->w * superficieInfo->format->BytesPerPixel, superficieInfo->format->Rmask, superficieInfo->format->Gmask,
				superficieInfo->format->Bmask, superficieInfo->format->Amask);

			if (superficieGuardada == nullptr) {
			}



			IMG_SavePNG(superficieGuardada, filename.c_str());
			SDL_FreeSurface(superficieGuardada);
		}


		SDL_Surface* load_image(std::string filename)
		{
			//The image that's loaded
			SDL_Surface* loadedImage = NULL;

			//The optimized image that will be used
			SDL_Surface* optimizedImage = NULL;

			//Load the image
			loadedImage = IMG_Load(filename.c_str());

			//If the image loaded
			//if (loadedImage != NULL)
			//{
			//	//Create an optimized image
			//	//optimizedImage = SDL_DisplayFormat(loadedImage);

			//	//Free the old image
			//	SDL_FreeSurface(loadedImage);
			//}

			//Return the optimized image
			return loadedImage;
		}

private: System::Windows::Forms::Panel^ panel1;

private: System::ComponentModel::IContainer^ components;
protected:

protected:


protected:

	protected:


	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->panel1->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->panel1->Location = System::Drawing::Point(55, 77);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(481, 351);
			this->panel1->TabIndex = 0;
			this->panel1->SizeChanged += gcnew System::EventHandler(this, &MainForm::panel1_SizeChanged);
			this->panel1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &MainForm::panel1_MouseDown);
			this->panel1->Resize += gcnew System::EventHandler(this, &MainForm::panel1_Resize);
			// 
			// timer1
			// 
			this->timer1->Interval = 5;
			this->timer1->Tick += gcnew System::EventHandler(this, &MainForm::timer1_Tick);
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(393, 28);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 1;
			this->button1->Text = L"button1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MainForm::button1_Click_1);
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(548, 440);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->panel1);
			this->Name = L"MainForm";
			this->Text = L"MainForm";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {

		while (1)
		{
			SDL_RenderPresent(renderer);

			panel1->Invalidate();
			panel1->Refresh();

			Myevents();
			Render();
		}
	}
private: System::Void timer1_Tick(System::Object^ sender, System::EventArgs^ e) {



	SDL_RenderPresent(renderer);

	panel1->Invalidate();
	panel1->Refresh();

	Myevents();
	Render();

}
private: System::Void panel1_Resize(System::Object^ sender, System::EventArgs^ e) 
{



}
private: System::Void panel1_SizeChanged(System::Object^ sender, System::EventArgs^ e) 
{


}
private: System::Void panel1_MouseDown(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e)
{

}
private: System::Void button1_Click_1(System::Object^ sender, System::EventArgs^ e) {

	while (1)
	{
		SDL_RenderPresent(renderer);

		panel1->Invalidate();
		panel1->Refresh();

		Myevents();
		Render();
	}

}
};
}
