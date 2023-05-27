#include "logger.hpp"

void registerLogCallback(LogCallback callback)
{
    callbackInstance = callback;
}


void Logger::log(const char* message)
{
    if (callbackInstance != nullptr)
        callbackInstance(message, (int)strlen(message));
}

void Logger::log(const std::string message)
{
    log(message.c_str());
}

void Logger::log(int message)
{
    std::stringstream ss;
    ss << message;
    sendLog(ss);
}

void Logger::log(float message)
{
    std::stringstream ss;
    ss << message;
    sendLog(ss);
}

void Logger::log(bool message)
{
    std::stringstream ss;
    ss << message;
    sendLog(ss);
}

void Logger::sendLog(const std::stringstream &ss)
{
    if (callbackInstance == nullptr) return;
    const std::string tmp = ss.str();
    const char* message = tmp.c_str();
    callbackInstance(message, (int)strlen(message));
}
