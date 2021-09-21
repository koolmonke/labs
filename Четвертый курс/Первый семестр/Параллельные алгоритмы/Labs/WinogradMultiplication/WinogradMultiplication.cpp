#include <iostream>
#include <omp.h>
#include <chrono>
#include <random>


constexpr auto N = 1000;

int A[N][N];
int B[N][N];
int C[N][N];
int rowFactorA[N];
int columnFactorB[N];


int main()
{
	int i, j, k;
	std::random_device dev;
	std::mt19937 rng(dev());
	std::uniform_int_distribution<std::mt19937::result_type> dist(1, 100);

	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
		{
			A[i][j] = dist(rng);
			B[i][j] = dist(rng);
		}
	}


	auto start = std::chrono::high_resolution_clock::now();
	omp_set_num_threads(omp_get_num_procs());

#pragma omp parallel for private(i,j) shared(A,rowFactorA)
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N - 1; j += 2) {
			rowFactorA[i] -= A[i][j] * A[i][j + 1];
		}
	}

#pragma omp parallel for private(i,j) shared(B,columnFactorB)
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N - 1; j += 2)
		{
			columnFactorB[i] -= B[j][i] * B[j + 1][i];
		}
	}

#pragma omp parallel for private(i,j) shared(C, rowFactorA, columnFactorB)
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
		{
			C[i][j] = rowFactorA[i] + columnFactorB[j];
		}

	}

#pragma omp parallel for private(i,j,k) shared(A,B,C)
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
		{
			for (k = 0; k < N - 1; k += 2) {

				C[i][j] += (A[i][k + 1] + B[k][j]) * (A[i][k] + B[k + 1][j]);;
			}
		}
	}

	if (N % 2 == 1) {
		for (i = 0; i < N; i++)
		{
			for (j = 0; i < N; i++)
			{
				C[i][j] += A[i][N - 1] * B[N - 1][j];
			}
		}
	}

	auto stop = std::chrono::high_resolution_clock::now();;
	auto duration = std::chrono::duration_cast<std::chrono::microseconds>(stop - start);
	std::cout << "Took " << duration.count() << " microseconds" << std::endl;

}