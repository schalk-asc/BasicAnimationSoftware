#pragma once


#include "SDL.h"
#include "Windows.h"
#include "SDL_syswm.h"
#include "SDL_image.h"
#include "SDL_ttf.h"

#include <iostream>
#include <fstream>

#include <msclr/marshal_cppstd.h>


using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace testlibrary2 {

	public enum class AvailableTools : char { Brush };

	/// <summary>
	/// Summary for MyUserControl
	/// </summary>
	public ref class MyUserControl : public System::Windows::Forms::UserControl
	{
	public:

		SDL_Window* window;
		SDL_Renderer* renderer;
		int current_mousepositionx;

		AvailableTools CurrentTool = AvailableTools::Brush;


		Color SelectedColor;
		bool executing = false;

		bool test11 = false;


	private: System::Windows::Forms::Panel^ MainPanel;
	public:

	public:
		int current_mousepositiony;




		MyUserControl(void)
		{
			InitializeComponent();

			OutputDebugStringA("aaa");
		}

		void EmbedCalc(HWND Parent, HWND Son)
		{
			//HWND Son = FindWindow(L"CalcFrame", NULL);
			if (Son != NULL)
			{
				// Change the parent so the calc window belongs to our apps main window 
				SetParent(Son, Parent);

				// Update the style so the calc window is embedded in our main window
				// SetWindowLong(Son, GWL_STYLE, GetWindowLong(Son, GWL_STYLE) | WS_CHILD);

				// We need to update the position as well since changing the parent does not
				// adjust it automatically.
				SetWindowPos(Son, NULL, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
			}
		}

		void Inicialize()
		{
			HWND hWndPictureBox = static_cast<HWND>(MainPanel->Handle.ToPointer());
			if (SDL_Init(SDL_INIT_VIDEO) < 0) {

			}


			//SDL_SetHint(SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT, "%p");

			window = SDL_CreateWindow("Mi Ventana", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, MainPanel->Width, MainPanel->Height, SDL_WINDOW_BORDERLESS);

			SDL_Init(SDL_INIT_VIDEO);
			


			SDL_SysWMinfo wmInfo;
			SDL_GetWindowWMInfo(window, &wmInfo);
			HWND hwnd = wmInfo.info.win.window;
			EmbedCalc(hWndPictureBox, hwnd);



			renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);

		}

		void clear()
		{
			SDL_SetRenderDrawColor(renderer, 135, 206, 235, 255);
			// Clears the current render surface.

			SDL_RenderClear(renderer);
		}

		void captureEvents()
		{
			Myevents();
		}

		void Render()
		{
			SDL_RenderPresent(renderer);
		}

		void SaveImage(System::String^ path)
		{
			SDL_Surface* superficieInfo = SDL_GetWindowSurface(window);
			std::string miStringStd = msclr::interop::marshal_as<std::string>(path);
			save_image(miStringStd, superficieInfo);
		}

		void RenderFunction(System::String^ path)
		{

			std::string miStringStd = msclr::interop::marshal_as<std::string>(path);

			SDL_Surface* image = load_image(miStringStd.c_str());

			SDL_Texture* imageTexture = SDL_CreateTextureFromSurface(renderer, image);

			int w, h;
			SDL_QueryTexture(imageTexture, NULL, NULL, &w, &h);

			SDL_Rect texr;
			texr.x = 0;
			texr.y = 0;
			texr.w = w;
			texr.h = h;

			SDL_RenderCopy(renderer, imageTexture, NULL, &texr);
		}

		void Myevents()
		{
			SDL_Event evento;
			//SDL_PollEvent(&evento);

			int x1, y2;
			Uint32 buttons = SDL_GetMouseState(&x1, &y2);
			current_mousepositionx = x1;
			current_mousepositiony = y2;

			while (SDL_PollEvent(&evento)) 
			{  // poll until all events are handled!
				switch (evento.type)
				{
				case SDL_QUIT:

					break;
				case SDL_MOUSEBUTTONDOWN:
					if (evento.button.button == SDL_BUTTON_LEFT)
					{
						executing = true;
					}
					break;
				case SDL_MOUSEBUTTONUP:
					if (evento.button.button == SDL_BUTTON_LEFT)
					{
						executing = false;
					}
					break;
				}
			}


			if (executing)
			{
				executePaintComand();
			}

			
		}

		void CloseWindows()
		{
			SDL_DestroyWindow(window);
			SDL_Quit();
		}


		void SetTool(AvailableTools SelectedTool)
		{
			this->CurrentTool = SelectedTool;
		}

		System::String^ BrushPath;

		void SetBrush(System::String^ path,Color selectedColor)
		{
			SelectedColor = selectedColor;
			BrushPath = path;
		}


	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyUserControl()
		{
			if (components)
			{
				delete components;
			}
		}
	private: 
	protected:

		void executePaintComand()
		{
			switch (CurrentTool)
			{
				case AvailableTools::Brush:

					System::String^ BrushPath2 = BrushPath;
					std::string miStringStd = msclr::interop::marshal_as<std::string>(BrushPath2);

					SDL_Surface* image = load_image(miStringStd);

					SDL_Texture* imageTexture = SDL_CreateTextureFromSurface(renderer, image);

					SDL_SetTextureColorMod(imageTexture, SelectedColor.R, SelectedColor.G, SelectedColor.B);

					int w, h;
					SDL_QueryTexture(imageTexture, NULL, NULL, &w, &h);

					SDL_Rect texr;
					texr.x = current_mousepositionx-(w/2);
					texr.y = current_mousepositiony-(h/2);
					texr.w = w;
					texr.h = h;

					SDL_RenderCopy(renderer, imageTexture, NULL, &texr);

				break;
			}
		}

	

		SDL_Surface* load_image(std::string filename)
		{
			SDL_Surface* loadedImage = NULL;

			SDL_Surface* optimizedImage = NULL;

			//Load the image
			loadedImage = IMG_Load(filename.c_str());
	
			//If the image loaded
			if (loadedImage != NULL)
			{
			//	//Create an optimized image
				//optimizedImage = SDL_DisplayFormat(loadedImage);

			//	//Free the old image
			//	SDL_FreeSurface(loadedImage);
			}

			//Return the optimized image
			return loadedImage;
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


	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->MainPanel = (gcnew System::Windows::Forms::Panel());
			this->SuspendLayout();
			// 
			// MainPanel
			// 
			this->MainPanel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->MainPanel->Location = System::Drawing::Point(0, 0);
			this->MainPanel->Name = L"MainPanel";
			this->MainPanel->Size = System::Drawing::Size(474, 369);
			this->MainPanel->TabIndex = 0;
			// 
			// MyUserControl
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ActiveCaption;
			this->Controls->Add(this->MainPanel);
			this->Name = L"MyUserControl";
			this->Size = System::Drawing::Size(474, 369);
			this->ResumeLayout(false);

		}
#pragma endregion
	};
}
