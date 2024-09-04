#include <iostream>
using namespace std;
int main()
{
	int sayi;
	cout << "bir sayi giriniz: ";
	cin >> sayi;

	if (sayi%3==0 || sayi%5==0 || sayi%7==0)
	{
		cout << "sayiniz 3,5 veye 7 ye tam bolunmektedir";
	}

	else
	{
		cout << "sayiniz 3,5 veya 7 ye bolunmemektedir";
	}
}