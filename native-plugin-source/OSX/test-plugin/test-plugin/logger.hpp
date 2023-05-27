#ifndef logger_hpp
#define logger_hpp

#include <stdio.h>
#include <string>
#include <sstream>

extern "C"
{
    typedef void(*LogCallback)(const char* message, int size); // コールバックの型
    static LogCallback callbackInstance = nullptr;
    void registerLogCallback(LogCallback callback);
}

class Logger
{
public:
    static void log(const char* message);
    static void log(const std::string message);
    static void log(int message);
    static void log(float message);
    static void log(bool message);

private:
    static void sendLog(const std::stringstream &ss);
};

#endif /* logger_hpp */
