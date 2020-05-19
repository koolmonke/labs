binary: main.o of.o err1.o stfile.o df.o rf.o cp.o md.o rd.o  
	g++ -o binary main.o stfile.o of.o rf.o df.o rd.o err1.o cp.o md.o 
main.o: main.cpp
	g++ -c main.cpp  
of.o: of.cpp
	g++ -c of.cpp 
err1.o: err1.cpp
	g++ -c err1.cpp 
df.o: df.cpp
	g++ -c df.cpp
cp.o: cp.cpp
	g++ -c cp.cpp
md.o: md.cpp
	g++ -c md.cpp
rd.o: rd.cpp
	g++ -c rd.cpp
rf.o: rf.cpp
	g++ -c rf.cpp
stfile.o: stfile.cpp
	g++ -c stfile.cpp
clean:
	rm -f *.o binary 
