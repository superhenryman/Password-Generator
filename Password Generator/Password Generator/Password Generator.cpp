#include <iostream>
#include <string>
void help() {
	std::cout << "Use: " << std::endl;
	std::cout << "   /h or -h == Show this menu    " << std::endl;
	std::cout << "Write: " << "gen.exe {password length}" << std::endl;
	std::cout << "-------------------------------------------------" << std::endl;
	std::cout << "Will return the password in stdout. you can use gen.exe {password length} > password.txt" << std::endl;
}

int main(int argc, char* argv[]) {

	if (argc < 2) {
		help();
		return 1;
	}
	std::string password = "";
	if (argv[1] == std::string("-h") || argv[1] == std::string("/h")) {
		help();
		return 0;
	}
	try {
		int passlength = std::stoi(argv[1]);
		if (passlength <= 0) {
			std::cout << "Password Length cannot be lower or equal to 0." << std::endl;
			return 1;
		}
		char chars[] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
		int num_chars = sizeof(chars) - 1;
		srand(static_cast<unsigned int>(time(0)));
		for (int i = 0; i < passlength; i++) {
			password += chars[rand() % num_chars];
		}
		std::cout << password << std::endl;
	}
	catch (const std::invalid_argument&) {
		std::cout << "Invalid argument. Please provide a valid number for password length." << std::endl;
		return 1;

	}
	catch (const std::out_of_range&) {
		std::cout << "Number too large. Please enter a reasonable password length." << std::endl;
		return 1;
	}
	return 0;
}