#import <Foundation/Foundation.h>

@interface Example : NSObject

+ (int32_t)printHelloWorld;

@end

@implementation Example

+ (int32_t)printHelloWorld {
    NSLog(@"Hello World");
    return 0;
}

@end


#ifdef _cplusplus
extern "C" {
#endif

int32_t printHelloWorld() {
    return 0;
    //return [Example printHelloWorld];
}

#ifdef _cplusplus
}
#endif
