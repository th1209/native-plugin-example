#include "marshalling_example.hpp"
#include <iostream>

void passString(const char* value)
{
    if (value == nullptr)
    {
        std::cout << "string value was null" << std::endl;
        return;
    }
    std::cout << value << std::endl;
}

void passInt(const int value)
{
    std::cout << value << std::endl;
}

void passFloat(const float value)
{
    std::cout << value << std::endl;
}
