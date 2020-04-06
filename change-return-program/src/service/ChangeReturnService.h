//
// Created by Gjorovski on 4/6/2020.
//

#ifndef CHANGE_RETURN_PROGRAM_CHANGERETURNSERVICE_H
#define CHANGE_RETURN_PROGRAM_CHANGERETURNSERVICE_H


#include <utility>
#include <vector>

class ChangeReturnService {
private:
    float price;
    float payment;

public:
    ChangeReturnService(float price, float payment);
    std::vector<int> calculate();
};


#endif //CHANGE_RETURN_PROGRAM_CHANGERETURNSERVICE_H
