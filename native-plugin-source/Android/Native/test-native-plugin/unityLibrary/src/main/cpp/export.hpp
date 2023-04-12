#ifndef export_hpp
#define export_hpp

class ExportTest
{
public:
    int TestFunc(int num);
};

extern "C"
{
ExportTest* createExportTest();
void freeExportTest(ExportTest* instance);
int getResult(ExportTest* instance, int num);
}

#endif /* export_hpp */