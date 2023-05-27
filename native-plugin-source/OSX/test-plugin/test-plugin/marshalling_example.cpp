#include "marshalling_example.hpp"
#include "logger.hpp"
#include <iostream>

void passString(const char* value)
{
    if (value == nullptr)
    {
        Logger::log("string value was null");
        return;
    }
    Logger::log(value);
}

void passInt(const int value)
{
    Logger::log(value);
}

void passFloat(const float value)
{
    Logger::log(value);
}
