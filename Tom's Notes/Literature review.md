### Simulation algorithms:
[N-body simulation - Wikipedia](https://en.wikipedia.org/wiki/N-body_simulation)

##### Barnes Hut 
- $O(nlog(n))$
- Divides simulation space recursively into octree
- Treats distant octree 'boxes' as signle particles

##### All pairs
- $O(n^2)$
- Calcultaes the forces between all objects pairwise
- Most physical but incredibly computationally intensive

##### Parallel multipole tree algorithm
- Hybrid of barnes hut and another algo we're not going to consider (Fast multipole method)

##### Runge-kutta method
- Algo for omptimising numerical integration, gives 4th order accuracy compared to leapfrogging which is only 2nd order

##### Particle mesh method
- Space divided into discretised mesh where gravitational potential is calculated using FFT and the poission eqn.
- Often combined with other techniques to improve perfromance.


### Unreal engine graphics
- [(157) How to create a Space Scene in Unreal Engine Part 2 || Unreal Engine 5 Tutorial - YouTube](https://www.youtube.com/watch?v=uH0EUmQ-h-I&t=2489s)
- A low resolution/ less realistic verion would provide both compelling and perfomative experience

go to bottom of page:
[OpenCL | NVIDIA Developer](https://developer.nvidia.com/opencl)

Using both cpu and gpu for maximum barnes hut performance:
[A Hybrid Parallel Barnes-Hut Algorithm for GPU and Multicore Architectures | SpringerLink](https://link.springer.com/chapter/10.1007/978-3-642-40047-6_57)