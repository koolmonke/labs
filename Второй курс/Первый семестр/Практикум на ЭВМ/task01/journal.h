#pragma once
#include "pechatnoe_izdanie.h"
class journal :
	public pechatnoe_izdanie
{
public:
	journal(std::string name);
	~journal();
	pechatnoe_izdanie* Add();
	void Show();
	journal(const journal& toCopy);
};

journal::journal(std::string name) : pechatnoe_izdanie(name) { type = "Журнал"; }

journal::~journal() {}

pechatnoe_izdanie *journal::Add() {
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
  return first;
}

void journal::Show() {
  cout << "Это журнал"<< endl;
  cout << bookName << ", " << type << endl;
}

journal::journal(const journal &toCopy) {
  this->~journal();
  bookName = toCopy.bookName;
  type = toCopy.type;
}