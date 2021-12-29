#include <iostream>
#include <string>

using namespace std;

class Bytes {
  unsigned char *pusc;
  bool initialized;
  unsigned char *ppos;

 public:
  void init(int size);
  void free();
  void startreading();
  Bytes();
  ~Bytes();
  Bytes &operator<<(int &val);
  Bytes &operator>>(int &val);
  Bytes &operator<<(double &val);
  Bytes &operator>>(double &val);
  Bytes &operator<<(wstring &val);
  Bytes &operator>>(wstring &val);
};



int main() {
  Bytes binstream;
  int bsize;
  int a = 123;
  bsize = sizeof(a);
  binstream.init(bsize);
  binstream << a;
  int b;
  binstream.startreading();
  binstream >> b;
  binstream.free();
  cout << "int b=" << b << endl;
    
  double d = 456.789;
  bsize = sizeof(d);
  binstream.init(bsize);
  binstream << d;
  double e;
  binstream.startreading();
  binstream >> e;
  binstream.free();
  cout << "double d=" << d << endl;
  wstring ws(L"a String of Wide-Chars");
  bsize = sizeof(int) + (sizeof(wchar_t) * (int)(ws.length()));
  binstream.init(bsize);
  binstream << ws;

  wstring xs;
  binstream.startreading();
  binstream >> xs;
  binstream.free();
  wcout << "wstring xs=\"" << xs << "\"" << endl;
  return 0;
}
void Bytes::init(int size) {
  pusc = new unsigned char[size];
  ppos = pusc;
  initialized = true;
}
void Bytes::free() {
  delete[] pusc;
  pusc = NULL;
  ppos = pusc;
  initialized = false;
}
void Bytes::startreading() { ppos = pusc; }
Bytes::Bytes() : pusc(NULL), initialized(false), ppos(pusc) {}
Bytes::~Bytes() {
  if (initialized) free();
}
Bytes &Bytes::operator<<(int &val) {
  int *pdest = (int *)ppos;
  *pdest++ = val;
  ppos = (unsigned char *)pdest;
  return *this;
}
Bytes &Bytes::operator>>(int &val) {
  int *psrc = (int *)ppos;
  val = *psrc++;
  ppos = (unsigned char *)psrc;
  return *this;
}
Bytes &Bytes::operator<<(double &val) {
  double *pdest = (double *)ppos;
  *pdest++ = val;
  ppos = (unsigned char *)pdest;
  return *this;
}
Bytes &Bytes::operator>>(double &val) {
  double *psrc = (double *)ppos;
  val = *psrc++;
  ppos = (unsigned char *)psrc;
  return *this;
}
Bytes &Bytes::operator<<(wstring &val) {
  int wsize = (int)val.length();
  *this << wsize;
  wchar_t *pdest = (wchar_t *)ppos;
  const wchar_t *psrc = val.c_str();
  while (*psrc != L'\0') *pdest++ = *psrc++;
  ppos = (unsigned char *)pdest;
  return *this;
}
Bytes &Bytes::operator>>(wstring &val) {
  int wsize;
  *this >> wsize;
  val = wstring((wchar_t *)ppos, wsize);
  ppos += wsize * sizeof(wchar_t);
  return *this;
}