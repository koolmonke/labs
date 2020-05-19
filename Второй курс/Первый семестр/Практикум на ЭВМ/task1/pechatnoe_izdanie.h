#pragma once
#include <string>
#include <iostream>
#include <exception>

using namespace std;

class pechatnoe_izdanie	{
public:
	pechatnoe_izdanie();
	pechatnoe_izdanie(std::string);
	pechatnoe_izdanie(const pechatnoe_izdanie&);
	~pechatnoe_izdanie();
	static void ShowList();
	virtual pechatnoe_izdanie* Add();
	virtual void Show();
	static pechatnoe_izdanie* first;
	pechatnoe_izdanie* next;
protected:
	std::string bookName;
	std::string type;
};

pechatnoe_izdanie::pechatnoe_izdanie() {
  bookName = "Абстрактия";
  type = "Печатное издание(абстрактный класс)";
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
}

pechatnoe_izdanie::pechatnoe_izdanie(std::string name) {
  bookName = name;
  type = "Печатное издание(абстрактный класс)";
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
}

pechatnoe_izdanie::pechatnoe_izdanie(const pechatnoe_izdanie &toCopy) {
  this->~pechatnoe_izdanie();
  bookName = toCopy.bookName;
  type = toCopy.type;
}

pechatnoe_izdanie::~pechatnoe_izdanie() {
  bookName.empty() ? cout << endl
                      : cout << bookName << " удаляется" << endl;
  if (first && !bookName.empty()) {
    pechatnoe_izdanie *current = first;
    pechatnoe_izdanie *prev = 0;
    while (current->bookName != this->bookName) {
      prev = current;
      current = current->next;
    }

    (prev ? prev->next : first) = current->next;
  }
  bookName.clear();
  type.clear();
  cout << endl;
}

void pechatnoe_izdanie::ShowList() {
  if (!first)
    throw length_error("");

  pechatnoe_izdanie *current = first;
  while (current) {
    cout << current->bookName << ", " << current->type << endl;
    current = current->next;
  }
}

pechatnoe_izdanie *pechatnoe_izdanie::Add() {
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
  return first;
}

void pechatnoe_izdanie::Show() {
  cout << "Вызвано печатное издание" << endl;
  cout << bookName << ", " << type << endl;
}
