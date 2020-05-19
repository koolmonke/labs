#include <iostream>

#include "pechatnoe_izdanie.h"
#include "textbook.h"
#include "knigga.h"
#include "journal.h"

pechatnoe_izdanie* pechatnoe_izdanie::first = 0;

int main() {
	pechatnoe_izdanie a;
	a.Show();
	//a.Add();
	//pechatnoe_izdanie::ShowList();

	cout << endl;

	pechatnoe_izdanie* b = new pechatnoe_izdanie("ААААА");
	b->Show();
	//b.Add();
	//pechatnoe_izdanie::ShowList();

	cout << endl;

    pechatnoe_izdanie *c = new textbook("ОООО");
    c->Show();
	//c.Add();
	//pechatnoe_izdanie::ShowList();

	cout << endl;

	pechatnoe_izdanie* d = new journal("АА");
	d->Show();
	//d.Add();
	//pechatnoe_izdanie::ShowList();

	cout << endl;

	pechatnoe_izdanie* e = new knigga("АААААААААААААААААА");
	e->Show();
	//e.Add();
	//pechatnoe_izdanie::ShowList();

	cout << endl;

	pechatnoe_izdanie::ShowList();
	delete e;
	delete d;
	pechatnoe_izdanie::ShowList();

	cout << endl;
}