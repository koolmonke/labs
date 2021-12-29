#pragma once
#include "pechatnoe_izdanie.h"
class knigga :
	public pechatnoe_izdanie
{


public:
	knigga(std::string name);
	knigga(const knigga& toCopy);
	~knigga();
	pechatnoe_izdanie* Add();
	void Show();
};

knigga::knigga(std::string name) : pechatnoe_izdanie(name) { type = "Книга"; }

knigga::~knigga() {}

pechatnoe_izdanie *knigga::Add() {
  pechatnoe_izdanie *toAdd = this;
  toAdd->next = first ? first : 0;
  first = toAdd;
  return first;
}

void knigga::Show() {
  cout << "Эта книга называется:" << endl;
  cout << bookName << ", " << type << endl;
}

knigga::knigga(const knigga &toCopy) {
  this->~knigga();
  bookName = toCopy.bookName;
  type = toCopy.type;
}