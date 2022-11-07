# %%
from initialise import initialise_bodies
from plot import animate_bodies
from numpy import array, append


tsteps = 100
delta_t = 1
bounds = array([100,100,100])

if __name__ == '__main__':

    print ("Starting simulation")
    print (f"Duration: {tsteps*delta_t} Timestep: {delta_t}")
    
    bodies = initialise_bodies(100, dimensions=bounds)
    t = 0
    time_array = array([])
    

    while t < tsteps:

        time_array = append(time_array, t)

        for body in bodies:
            body.store_data()
            body.update_position(delta_t, bounds)

        t += 1

    print ("Simulation complete")
    animate_bodies(bodies)



# %%
