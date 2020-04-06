#include <iostream>
#include <string>

#include "service/ChangeReturnService.h"

int main(int count, char** args) {
    if (count != 3) {
        std::cout << "Insufficient number of parameters." << std::endl;
        return 1;
    }

    float price = 0;
    float payment = 0;
    try {
        price = std::stof(args[1]);
        payment = std::stof(args[2]);
    } catch (const std::exception& exc) {
        std::cout << "Invalid parameters provided." << std::endl;
        return 1;
    }

    auto service = new ChangeReturnService(price, payment);
    std::cout << "Quarters: " << service->calculate()[0].second << std::endl;
    std::cout << "Dimes: " << service->calculate()[1].second << std::endl;
    std::cout << "Nickels: " << service->calculate()[2].second << std::endl;
    std::cout << "Pennies: " << service->calculate()[3].second << std::endl;

    return 0;
}
