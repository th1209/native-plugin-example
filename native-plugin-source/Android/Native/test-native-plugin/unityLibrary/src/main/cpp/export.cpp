#include "export.hpp"

int ExportTest::TestFunc(int num)
{
    return num + 5;
}

ExportTest* createExportTest()
{
    return new ExportTest;
}

void freeExportTest(ExportTest* instance)
{
    delete instance;
}

int getResult(ExportTest* instance, int num)
{
    return instance->TestFunc(num);
}
