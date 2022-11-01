#include "KY037.h"

bool soundIsActive(){

    return digitalRead(SOUNDSENSORPIN);
}
