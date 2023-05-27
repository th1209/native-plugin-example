#ifndef marshalling_example_h
#define marshalling_example_h

extern "C"
{
    void passString(const char* value);
    void passInt(const int value);
    void passFloat(const float value);
}

#endif /* marshalling_example_h */

