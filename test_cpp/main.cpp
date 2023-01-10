#include <iostream>
#include "Body.hpp"

int main(){
Body first(1.0);
std::cout << first.x << std::endl;

//This doesnt output 1?!!

return EXIT_SUCCESS;
}