#pragma once
#include "pechatnoe_izdanie.h"
class textbook :
	public pechatnoe_izdanie
{
public:
	textbook(std::string name);
	textbook(const textbook& toCopy);
	~textbook();
	pechatnoe_izdanie* Add();
	void Show();
};

textbook::textbook(std::string name) : pechatnoe_izdanie(name) { type = "Учебник"; }

textbook::~textbook() {}

pechatnoe_izdanie *textbook::Add() {
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
  return first;
}

void textbook::Show() {
  cout << "Это учебник" << endl;
  cout << bookName << ", " << type << endl;
}

textbook::textbook(const textbook &toCopy) {
  this->~textbook();
  bookName = toCopy.bookName;
  type = toCopy.type;
}