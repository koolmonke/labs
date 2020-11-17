#include "freeglut.h"
#include <windows.h>
#include <GL/GL.h>
#include <GL/GLU.h>
#include <time.h>
#include "Glaux.h"
#include "glext.h"
#pragma comment(lib,"opengl32.lib")
#pragma comment(lib,"glu32.lib")
#pragma comment(lib,"Glaux.lib")
#pragma comment (lib, "legacy_stdio_definitions.lib")


static HGLRC hRC;		// Постоянный контекст рендеринга
static HDC hDC;			// Приватный контекст устройства GDI

BOOL	keys[256];		// Массив для процедуры обработки клавиатуры
GLUquadricObj* cone;
GLuint tree;
GLuint	texture[6];			// Место для одной текстур
DWORD start;
GLfloat curtime;
GLfloat curz = -85.0f, curugl, curz2;
bool polygonmode = false;
bool pause = false;
void Tree(GLfloat l)
{
	if (l < 0.3f)
		return;
	GLfloat x1, y1, z1, v, l1;
	if (l >= 2.0)
		glColor3f(0.8, 0.3, 0.2);
	else
		glColor3f(0.3, 0.8, 0.2);
	glPushMatrix();
	glRotatef(90, -1.0, 0.0, 0.0);
	gluCylinder(cone, l / 30.0, 0.05, l, 8, 1);
	glPopMatrix();
	if (l >= 2.0)
	{
		glColor3f(0.3, 0.8, 0.2);
		for (int i = 0; i <= 40; i++)
		{
			glPushMatrix();
			glTranslatef(0.0f, l - 3.0 * (GLfloat)(rand() % 20) / 22.0f, 0.0f);
			x1 = 180 + rand() % 180;
			y1 = rand() % 360;
			z1 = 180 + rand() % 180;
			glPushMatrix();
			glRotatef(y1, 0.0, 1.0, 0.0);
			glRotatef(x1, 1.0, 0.0, 0.0);
			glRotatef(z1, 0.0, 0.0, 1.0);
			gluCylinder(cone, 0.01, 0.05, l / 10, 4, 1);
			glPopMatrix();
			glPopMatrix();
		}
	}
	for (int i = 0; i <= 10 - rand() % 8; ++i)
	{
		glPushMatrix();
		v = l / 3 + (l / 2) * (rand() % 10) / 11.0;
		glTranslatef(0.0, v, 0.0);
		x1 = rand() % 80;
		y1 = rand() % 360;
		z1 = rand() % 80;
		glPushMatrix();
		glRotatef(y1, 0.0, 1.0, 0.0);
		glRotatef(x1, 1.0, 0.0, 0.0);
		glRotatef(z1, 0.0, 0.0, 1.0);
		l1 = l / 4.0 + (l / 4.0) * (rand() % 10) / 11.0;
		Tree(l1);
		glPopMatrix();
		glPopMatrix();
	}
}
void Trava(GLfloat a, GLfloat b, GLfloat h, GLuint na, GLuint nb)
{
	GLfloat ax, ay, az;
	glPushMatrix();
	glRotatef(90, -1.0, 0.0, 0.0);
	for (GLuint x = 0; x <= na; x++)
		for (GLuint y = 0; y <= nb; y++)
		{
			glPushMatrix();
			glTranslatef(-a / 2.0 + x * a / na, -b / 2.0 + y * b / nb, 0.0f);
			ax = 20 - rand() % 41;
			ay = 20 - rand() % 41;
			az = rand() % 360;
			glRotatef(ax, 0.0, 1.0, 0.0);
			glRotatef(ay, 1.0, 0.0, 0.0);
			glRotatef(az, 0.0, 0.0, 1.0);
			gluCylinder(cone, 0.02, 0.005, h, 3, 2);
			glPopMatrix();
		}
	glPopMatrix();
}
// Загрузка картинки и конвертирование в текстуру
GLvoid LoadGLTextures()
{
	// Загрузка картинки
	AUX_RGBImageRec* texture1;
	texture1 = auxDIBImageLoad(L"floor.bmp");
	// Создание текстуры
	glGenTextures(6, texture);
	glBindTexture(GL_TEXTURE_2D, texture[0]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, texture1->sizeX, texture1->sizeY, 0, GL_RGB, GL_UNSIGNED_BYTE, texture1->data);
	texture1 = auxDIBImageLoad(L"terra.bmp");
	// Создание текстуры
	glBindTexture(GL_TEXTURE_2D, texture[1]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, texture1->sizeX, texture1->sizeY, 0, GL_RGB, GL_UNSIGNED_BYTE, texture1->data);
	texture1 = auxDIBImageLoad(L"kora.bmp");
	// Создание текстуры
	glBindTexture(GL_TEXTURE_2D, texture[2]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, texture1->sizeX, texture1->sizeY, 0, GL_RGB, GL_UNSIGNED_BYTE, texture1->data);
	texture1 = auxDIBImageLoad(L"vetki.bmp");
	// Создание текстуры
	glBindTexture(GL_TEXTURE_2D, texture[3]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, texture1->sizeX, texture1->sizeY, 0, GL_RGB, GL_UNSIGNED_BYTE, texture1->data);
}

GLvoid InitGL(GLsizei Width, GLsizei Height)	// Вызвать после создания окна GL
{
	glClearColor(0.2f, 0.8f, 1.0f, 1.0f);
	glClearDepth(1.0);		// Разрешить очистку буфера глубины
	glDepthFunc(GL_LESS);	// Тип теста глубины
	glEnable(GL_DEPTH_TEST);// разрешить тест глубины
	//glShadeModel(GL_SMOOTH);// разрешить плавное цветовое сглаживание
	glMatrixMode(GL_PROJECTION);// Выбор матрицы проекции
	glLoadIdentity();		// Сброс матрицы проекции
	gluPerspective(60.0f, (GLfloat)Width / (GLfloat)Height, 0.1f, 100.0f);
	// Вычислить соотношение геометрических размеров для окна
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
	glMatrixMode(GL_MODELVIEW);// Выбор матрицы просмотра модели

	srand(time(NULL));
	GLfloat pos[4] = { 0.0, 10.0, 50.0, 1.0 };
	GLfloat acol[4] = { 0.3, 0.3, 0.3, 1 };
	GLfloat dcol[4] = { 0.7, 0.7, 0.7, 1 };
	glLightfv(GL_LIGHT0, GL_POSITION, pos);
	//glLightfv(GL_LIGHT0, GL_AMBIENT, acol);
	//glLightfv(GL_LIGHT0, GL_DIFFUSE, dcol);
	glEnable(GL_LIGHT0);
	glEnable(GL_LIGHTING);
	//glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
	glEnable(GL_COLOR_MATERIAL);
	LoadGLTextures();			// Загрузка текстур
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);
	GLfloat fLargest;
	glGetFloatv(GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT, &fLargest);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAX_ANISOTROPY_EXT, fLargest);
	//	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAX_ANISOTROPY_EXT, 1.0f);
	cone = gluNewQuadric();
	gluQuadricTexture(cone, GL_TRUE);
	tree = glGenLists(5);
	glNewList(tree, GL_COMPILE);
	Tree(20.0);
	glEndList();
	glNewList(tree + 1, GL_COMPILE);
	Tree(20.0);
	glEndList();
	glNewList(tree + 2, GL_COMPILE);
	Tree(20.0);
	glEndList();
	glNewList(tree + 3, GL_COMPILE); // Ёлочка
	glPushMatrix();
	glRotatef(90, -1.0, 0.0, 0.0);
	glColor3f(0.8, 0.3, 0.2);
	glEnable(GL_TEXTURE_2D);	// Разрешение наложение текстуры
	glBindTexture(GL_TEXTURE_2D, texture[2]);
	gluCylinder(cone, 0.4, 0.4, 3.5, 5, 1);
	glBindTexture(GL_TEXTURE_2D, texture[3]);
	glColor3f(0.1, 0.4, 0.1);
	glTranslatef(0.0, 0.0, 3.0);
	gluCylinder(cone, 2.4, 0.05, 4.0, 7, 1);
	glTranslatef(0.0, 0.0, 2.5);
	gluCylinder(cone, 1.9, 0.05, 3.5, 5, 1);
	glTranslatef(0.0, 0.0, 2.5);
	gluCylinder(cone, 1.1, 0.05, 2.3, 5, 1);
	glPopMatrix();
	glDisable(GL_TEXTURE_2D);
	glEndList();
	//glNewList(tree + 4, GL_COMPILE); // Травка
	Trava(5, 160, 1, 30, 400);
	glEndList();
}

GLvoid ReSizeGLScene(GLsizei Width, GLsizei Height)
{
	if (Height == 0)		// Предотвращение деления на ноль, если окно слишком мало
		Height = 1;
	glViewport(0, 0, Width, Height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45.0f, (GLfloat)Width / (GLfloat)Height, 0.1f, 200.f);
	glTranslatef(0.0f, -2.0f, 0.0f);
	glRotatef(1.0f, 1.0f, 0.0f, 0.0f);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

GLvoid DrawGLScene(GLvoid)
{
	if (!pause) {
		curtime = (GLfloat)(GetTickCount() - start) / 1000.0f;
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); //очищаем буфер цвета и глубины
		//
		glLoadIdentity();
		if (curtime >= 0.0f && curtime <= 30.0f) // идем прямо 30 сек.
		{
			curz = -65.0f + 130.0f * curtime / 30.0;
			glTranslatef(0.0f, 0.0f, curz);
		}
		if (curtime >= 30.0f && curtime <= 35.0f) // поворот за 5 сек.
		{
			curugl = 180.0f * (curtime - 30.0f) / 5.0f;
			glRotatef(curugl, 0.0f, -1.0f, 0.0f);
			glTranslatef(0.0f, 0.0f, curz);
		}
		if (curtime >= 35.0f && curtime <= 65.0f) // идем назад 30 сек.
		{
			curz2 = curz - 130.0f * (curtime - 35.0f) / 30.0;
			glRotatef(curugl, 0.0f, -1.0f, 0.0f);
			glTranslatef(0.0f, 0.0f, curz2);
		}
		if (curtime >= 65.0f)
			start = GetTickCount();
	}
	//glColor3f(0.1f, 0.5f, 0.1f);
	glEnable(GL_TEXTURE_2D);	// Разрешение наложение текстуры
	glBindTexture(GL_TEXTURE_2D, texture[1]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, 1.0f, 0.0f);
	glTexCoord2f(0.0f, 0.0f); glVertex3f(-20.0f, 0.0f, -80.0f);
	glTexCoord2f(8.0f, 0.0f); glVertex3f(20.0f, 0.0f, -80.0f);
	glTexCoord2f(8.0f, 16.0f); glVertex3f(20.0f, 0.0f, 80.0f);
	glTexCoord2f(0.0f, 16.0f); glVertex3f(-20.0f, 0.0f, 80.0f);
	glEnd();
	//glColor3f(0.35f, 0.3f, 0.3f);

	glBindTexture(GL_TEXTURE_2D, texture[0]);
	glBegin(GL_QUADS);
	glNormal3f(0.0f, 1.0f, 0.0f);
	glTexCoord2f(0.0f, 0.0f); glVertex3f(-2.0f, 0.1f, -80.0f);
	glTexCoord2f(3.0f, 0.0f); glVertex3f(2.0f, 0.1f, -80.0f);
	glTexCoord2f(3.0f, 40.0f); glVertex3f(2.0f, 0.1f, 80.0f);
	glTexCoord2f(0.0f, 40.0f); glVertex3f(-2.0f, 0.1f, 80.0f);
	glEnd();
	glDisable(GL_TEXTURE_2D);
	// плакат
	//glPushMatrix();
	//glTranslatef(3.0f, 0.0f, 42.0f);
	//glRotatef(90, -1.0, 0.0, 0.0);
	//glColor3f(1.0, 1.0, 1.0);
	//gluCylinder(cone, 0.1, 0.1, 1, 5, 1);
	//glEnable(GL_TEXTURE_2D);
	//glBindTexture(GL_TEXTURE_2D, texture[1]);
	//glBegin(GL_QUADS);
	//glNormal3f(0.0f, -1.0f, 0.0f);
	//glTexCoord2f(0.0f, 0.0f); glVertex3f(-1.5f, -0.07f, 1.0f);
	//glTexCoord2f(1.0f, 0.0f); glVertex3f(1.5f, -0.07f, 1.0f);
	//glTexCoord2f(1.0f, 1.0f); glVertex3f(1.5f, -0.07f, 3.5f);
	//glTexCoord2f(0.0f, 1.0f); glVertex3f(-1.5f, -0.07f, 3.5f);
	//glEnd();
	//glBindTexture(GL_TEXTURE_2D, texture[1]);
	//glBegin(GL_QUADS);
	//glNormal3f(0.0f, 1.0f, 0.0f);
	//glTexCoord2f(0.0f, 0.0f); glVertex3f(1.5f, 0.07f, 1.0f);
	//glTexCoord2f(1.0f, 0.0f); glVertex3f(-1.5f, 0.07f, 1.0f);
	//glTexCoord2f(1.0f, 1.0f); glVertex3f(-1.5f, 0.07f, 3.5f);
	//glTexCoord2f(0.0f, 1.0f); glVertex3f(1.5f, 0.07f, 3.5f);
	//glEnd();
	//glPopMatrix();
	//glDisable(GL_TEXTURE_2D);
	//сажаем одно дерево
	//glPushMatrix();
	//glTranslatef(-18.0f, 0.f, -10.0f);
	//glCallList(tree);
	//glPopMatrix();
	//
	//glPushMatrix();
	//glTranslatef(17.0f, 0.f, -40.0f);
	//glCallList(tree + 1);
	//glPopMatrix();

	//glPushMatrix();
	//glTranslatef(18.0f, 0.f, 50.0f);
	//glCallList(tree + 2);
	//glPopMatrix();

	// "Насаждаем" ёлочки
	for (GLfloat i = -75.0f; i <= 75.0f; i += 8.0f)
	{
		glPushMatrix();
		glTranslatef(-5.0f, 0.0f, i);
		glCallList(tree + 3);
		glTranslatef(10.0f, 0.0f, 0.0f);
		glCallList(tree + 3);
		glPopMatrix();
	}
	glPushMatrix();
	glColor3f(0.6f, 1.0f, 0.1f);
	glTranslatef(-5.5f, 0.0f, 0.0f);
	glCallList(tree + 4);
	glTranslatef(11.0f, 0.0f, 0.0f);
	glCallList(tree + 4);
	glPopMatrix();
}

LRESULT CALLBACK WndProc(
	HWND	hWnd,
	UINT	message,
	WPARAM	wParam,
	LPARAM	lParam)
{
	RECT	Screen;		// используется позднее для размеров окна
	GLuint	PixelFormat;
	static	PIXELFORMATDESCRIPTOR pfd =
	{
		sizeof(PIXELFORMATDESCRIPTOR),	// Размер этой структуры
		1,				// Номер версии (?)
		PFD_DRAW_TO_WINDOW |// Формат для Окна
		PFD_SUPPORT_OPENGL |// Формат для OpenGL
		PFD_DOUBLEBUFFER,// Формат для двойного буфера
		PFD_TYPE_RGBA,	// Требуется RGBA формат
		16,				// Выбор 16 бит глубины цвета
		0, 0, 0, 0, 0, 0,// Игнорирование цветовых битов (?)
		0,				// нет буфера прозрачности
		0,				// Сдвиговый бит игнорируется (?)
		0,				// Нет буфера аккумуляции
		0, 0, 0, 0,		// Биты аккумуляции игнорируются (?)
		16,				// 16 битный Z-буфер (буфер глубины)  
		0,				// Нет буфера траффарета
		0,				// Нет вспомогательных буферов (?)
		PFD_MAIN_PLANE,	// Главный слой рисования
		0,				// Резерв (?)
		0, 0, 0			// Маски слоя игнорируются (?)
	};
	switch (message)	// Тип сообщения
	{
	case WM_CREATE:
		hDC = GetDC(hWnd);	// Получить контекст устройства для окна
		PixelFormat = ChoosePixelFormat(hDC, &pfd);
		// Найти ближайшее совпадение для нашего формата пикселов
		if (!PixelFormat)
		{
			MessageBox(0, L"Can't Find A Suitable PixelFormat.", L"Error", MB_OK | MB_ICONERROR);
			PostQuitMessage(0);
			// Это сообщение говорит, что программа должна завершится
			break;	// Предтовращение повтора кода
		}
		if (!SetPixelFormat(hDC, PixelFormat, &pfd))
		{
			MessageBox(0, L"Can't Set The PixelFormat.", L"Error", MB_OK | MB_ICONERROR);
			PostQuitMessage(0);
			break;
		}
		hRC = wglCreateContext(hDC);
		if (!hRC)
		{
			MessageBox(0, L"Can't Create A GL Rendering Context.", L"Error", MB_OK | MB_ICONERROR);
			PostQuitMessage(0);
			break;
		}
		if (!wglMakeCurrent(hDC, hRC))
		{
			MessageBox(0, L"Can't activate GLRC.", L"Error", MB_OK | MB_ICONERROR);
			PostQuitMessage(0);
			break;
		}
		GetClientRect(hWnd, &Screen);
		InitGL(Screen.right, Screen.bottom);
		break;

	case WM_DESTROY:
	case WM_CLOSE:
		//ChangeDisplaySettings(NULL, 0);
		glDeleteTextures(5, texture);
		glDeleteLists(tree, 3);
		gluDeleteQuadric(cone);
		wglMakeCurrent(hDC, NULL);
		wglDeleteContext(hRC);
		ReleaseDC(hWnd, hDC);

		PostQuitMessage(0);
		break;

	case WM_KEYDOWN:
		keys[wParam] = TRUE;
		if (wParam == 'M')
		{
			polygonmode = !polygonmode;
			if (polygonmode)
				glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
			else
				glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
		}
		if (wParam == 'P')
		{
			pause = !pause;
			if (!pause)
				start = GetTickCount() - curtime * 1000.0f;
		}
		break;

	case WM_KEYUP:
		keys[wParam] = FALSE;
		break;

	case WM_SIZE:
		ReSizeGLScene(LOWORD(lParam), HIWORD(lParam));
		break;

	default:
		return (DefWindowProc(hWnd, message, wParam, lParam));
	}
	return (0);
}

int WINAPI WinMain(
	HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,
	int nCmdShow)
{
	MSG		msg;	// Структура сообщения Windows
	WNDCLASS	wc; // Структура класса Windows для установки типа окна
	HWND		hWnd;// Сохранение дискриптора окна

	wc.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;
	wc.lpfnWndProc = (WNDPROC)WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = NULL;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = NULL;
	wc.lpszMenuName = NULL;
	wc.lpszClassName = L"OpenGL WinClass";

	if (!RegisterClass(&wc))
	{
		MessageBox(0, L"Failed To Register The Window Class.", L"Error", MB_OK | MB_ICONERROR);
		return FALSE;
	}

	hWnd = CreateWindow(
		L"OpenGL WinClass",
		L"Шаблон приложения OpenGL",
		WS_OVERLAPPEDWINDOW | WS_CLIPCHILDREN | WS_CLIPSIBLINGS |
		WS_CAPTION | WS_SYSMENU, CW_USEDEFAULT, CW_USEDEFAULT,
		800, 600,
		NULL,
		NULL,
		hInstance,
		NULL);

	if (!hWnd)
	{
		MessageBox(0, L"Window Creation Error.", L"Error", MB_OK | MB_ICONERROR);
		return FALSE;
	}

	/*DEVMODE dmScreenSettings;			// Режим работы

	memset(&dmScreenSettings, 0, sizeof(DEVMODE));	// Очистка для хранения установок
	dmScreenSettings.dmSize	= sizeof(DEVMODE);		// Размер структуры Devmode
	dmScreenSettings.dmPelsWidth	= 640;			// Ширина экрана
	dmScreenSettings.dmPelsHeight	= 480;			// Высота экрана
	dmScreenSettings.dmFields	= DM_PELSWIDTH | DM_PELSHEIGHT;	// Режим Пиксела
	ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN);
	// Переключение в полный экран
	*/
	ShowWindow(hWnd, SW_SHOW);
	UpdateWindow(hWnd);
	SetFocus(hWnd);
	start = GetTickCount(); // запоминаем время старта
	while (1)
	{
		// Обработка всех сообщений
		while (PeekMessage(&msg, NULL, 0, 0, PM_NOREMOVE))
		{
			if (GetMessage(&msg, NULL, 0, 0))
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
			else
			{
				return TRUE;
			}
		}
		DrawGLScene();				// Нарисовать сцену
		SwapBuffers(hDC);			// Переключить буфер экрана
		if (keys[VK_ESCAPE]) SendMessage(hWnd, WM_CLOSE, 0, 0);	// Если ESC - выйти
	}
}

