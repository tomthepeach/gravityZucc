from numpy import array, append

class Body:
    def __init__(self, idx: int, pos: array, vel: array, mass=1.0):
        self.mass = mass
        self.pos = pos
        self.vel = vel
        self.idx = idx
        self.pos_data = array([[],[],[]])
        self.vel_data = array([[],[],[]])

    def store_data(self):
        for i in range(3):
            self.pos_data[i] = append(self.pos_data[i], self.pos[i])
            self.vel_data[i] = append(self.vel_data[i], self.vel[i])

    def update_position(self, tstep, bounds):
        self.pos = (self.pos + self.vel*tstep) % bounds

        