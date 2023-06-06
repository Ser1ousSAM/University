from matplotlib.patches import Ellipse
import numpy as np
from random import randint

import matplotlib.pyplot as plt
plt.rcParams['toolbar'] = 'None'
fig, ax = plt.subplots()
ax.set_xlim(0, 1000)
ax.set_ylim(0, 1000)


def find_nearest_prototype(random_point, prototype_points):
    dis = 100000
    for p in prototype_points:
        distance = np.sqrt(
            (random_point[0]-p[0])**2 + (random_point[1]-p[1])**2)
        if (distance < dis):
            nearest_point = p
            dis = distance
    return nearest_point


# train material
x_values_one = []
y_values_one = []
x_values_two = []
y_values_two = []
for i in range(50):
    # uniform distribution
    x_values_one.append(randint(0, 500))
    y_values_one.append(randint(0, 500))
    # normal distribution
    x_values_two.append(int(np.random.normal(750, 100)))
    y_values_two.append(int(np.random.normal(750, 100)))
ax.plot(x_values_one, y_values_one, 'mo')
ax.plot(x_values_two, y_values_two, 'co')

# rectangle
xmin = min(x_values_one)
xmax = max(x_values_one)
ymin = min(y_values_one)
ymax = max(y_values_one)
rect = plt.Rectangle((xmin, ymin), xmax - xmin, ymax -
                     ymin, fill=False, edgecolor='pink')
plt.gca().add_patch(rect)

# ellipse
# covariances for cyan dots
covariance = np.cov(np.array([x_values_two, y_values_two]))
# vectors and values of the covariance matrix
eigen_values, eigen_vectors = np.linalg.eig(covariance)
# centroid for cyan dots
center = np.mean(np.array([x_values_two, y_values_two]), axis=1)
# the main eigenvector and its rotation angle
major_eigen_vector = eigen_vectors[np.argmax(eigen_values)]
angle = np.arctan2(major_eigen_vector[1], major_eigen_vector[0]) * 180 / np.pi
ellipse = Ellipse(center, 2 * np.sqrt(5.991 * eigen_values[0]), 2 * np.sqrt(
    5.991 * eigen_values[1]), angle=angle, fill=False, edgecolor='green')
ax.add_patch(ellipse)

# material exam
random_point = [randint(0, 1000), randint(0, 1000)]
print("rand point: ", *random_point)
plt.plot(random_point[0], random_point[1], 'bo')


prototype_points = [(x, y) for x, y in zip(x_values_one, y_values_one)] + \
    [(x, y) for x, y in zip(x_values_two, y_values_two)]
# the nearest reference point to a random point
nearest_prototype = find_nearest_prototype(random_point, prototype_points)
# draw the nearest point
print("the point of nearest prototype: ", *nearest_prototype)
plt.plot(nearest_prototype[0], nearest_prototype[1], 'yo')

# checking where is rand point
if nearest_prototype in [(x, y) for x, y in zip(x_values_one, y_values_one)]:
    print("magneta area")
elif nearest_prototype in [(x, y) for x, y in zip(x_values_two, y_values_two)]:
    print("cyan area")
else:
    print("neither magneta nor cyan")
plt.show()
