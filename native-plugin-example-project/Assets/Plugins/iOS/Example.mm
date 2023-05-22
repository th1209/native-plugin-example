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


#ifdef __cplusplus
extern "C" {
#endif

int32_t printHelloWorld() {
    return [Example printHelloWorld];
}

#ifdef __cplusplus
}
#endif
