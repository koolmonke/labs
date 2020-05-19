binary: main.o mylib.so
	gcc -o binary main.o -L.-I mylib.so -Wl,-rpath,.

main.o: main.c
	gcc -c main.c

mylib.so: er.o statfile.o openfile.o copyfile.o deldir.o renamefile.o delfile.o makedir.o
	gcc -shared -o mylib.so er.o openfile.o copyfile.o deldir.o delfile.o makedir.o statfile.o renamefile.o

delfile.o: delfile.c
	gcc -c -fPIC delfile.c

deldir.o: deldir.c
	gcc -c -fPIC deldir.c

makedir.o: makedir.c
	gcc -c -fPIC makedir.c

renamefile.o: renamefile.c
	gcc -c -fPIC renamefile.c

statfile.o: statfile.c
	gcc -c -fPIC statfile.c

copyfile.o: copyfile.c
	gcc -c -fPIC copyfile.c

openfile.o: openfile.c
	gcc -c -fPIC openfile.c

er.o: er.c
	gcc -c -fPIC er.c

clean:
	rm -f *.so *.o *.a binary
