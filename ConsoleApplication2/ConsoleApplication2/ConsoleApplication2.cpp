// VetClinicCode.cpp - Calculates total bill for servies
//Created/revised by <MCN29> on <12/3/10>

#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

int main()
{

	//function prototypes
	void getProgramName();
	void displayDogMenu();
	void displayCatMenu();


	//declare arrays
	int BATH_TYPE[3] = { 1,2,3 };
	double BATH_PRICE[3] = { 30.00, 20.00, 15.00 };


	//declare variables
	string name = " ";
	int animalType = 0;
	const int LARGE_DOG = 1;
	const int SMALL_DOG = 2;
	const int CAT = 3;
	int dogChoice = 0;
	int catChoice = 0;
	int sub = 0;
	double bathCat = 0;
	double totalBill = 0.0;
	double vetVisit = 0.0;
	double kennelService = 0.0;
	int numOfDays = 0;
	double totalKennel = 0.0;
	double bathDog = 0.0;
	double nailClipping = 0;
	const int SIZE = 3;

	//program name
	getProgramName();

	//get input from user
	cout << "Animal Name: ";
	getline(cin, name);
	cout << "Enter 1 for Cat or 2 for Dog: ";
	cin >> animalType;

	if (animalType == 1)
	{
		displayCatMenu();
		cout << "Enter 1, 2, 3, or 4: ";
		cin >> catChoice;
	} //end if

	while (catChoice > 0 && catChoice < 4)
	{
		if (catChoice == 1)
			bathCat = BATH_PRICE[sub];
		sub++;
		totalBill = totalBill + bathCat;


		if (catChoice == 2)
			vetVisit = 75.00;
		totalBill = totalBill + vetVisit;

		if (catChoice == 3)
			cout << "Enter Number of Days Kennel Service Was Used: ";
		cin >> numOfDays;
		totalKennel = (kennelService * numOfDays);
		totalBill = totalBill + totalKennel;


		if (catChoice == 4)
			cout << "Total Bill = " << totalBill << endl;


		//end if
		//get next menu choice

		displayCatMenu();
		cout << "Enter 1, 2, 3, or 4: ";
		cin >> catChoice;

	} //end while


	system("pause");
	return 0;
} //end of main function

//*****function definitions*****
void getProgramName()
{
	cout << "Vet Clinic Program" << endl;
} //end of getProgramName


void displayDogMenu()
{
	cout << "1 Bath: " << endl;
	cout << "2 Vet Visit: " << endl;
	cout << "3 Nail Clipping: " << endl;
	cout << "4 Kennel Serive: " << endl;
	cout << "5 Display Total Bill: " << endl;
}//end of displayDogMenu

void displayCatMenu()
{


	cout << "1 Bath: " << endl;
	cout << "2 Vet Visit: " << endl;
	cout << "3 Kennel Servie: " << endl;
	cout << "4 Display Total Bill: " << endl;

}//end displayCatMenu