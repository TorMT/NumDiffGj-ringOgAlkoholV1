import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import solve_ivp

# Parametere
umax = 0.5  # Maksimal veksthastighet (per time) (funnet via chatGBT og googling på diverse biologi sider)
K = 5       # Halvmetningskonstant (g/L) (funnet via chatGBT og googling på diverse biologi sider)
yx = 0.1    # Utbyttekoeffisient for gjærvekst (funnet via chatGBT og googling på diverse biologi sider)

# Initialverdier
s0 = 120     # Start sukkerkonsentrasjon (g/L)
x0 = 0.1     # Start gjærkonsentrasjon (g/L)

# Tidsinnstillinger
t_start = 0
t_end = 20 * 24  # 72 timer (3 dager)
dt = 0.1
n_steps = int((t_end - t_start) / dt)

# Tidsvektor for Euler-metoder
time = np.linspace(t_start, t_end, n_steps + 1)

# Fermenteringsmodell
def fermentation(t, y):
    s, x = y  # Sukker og gjær
    veksthastighet = umax * (s / (K + s)) * x
    ds_dt = -veksthastighet
    dx_dt = yx * veksthastighet
    return [ds_dt, dx_dt]

# Startbetingelser
y0 = [s0, x0]

# Tidsvektor for solve_ivp
t_eval = np.linspace(t_start, t_end, 500)

# Løsning med solve_ivp
sol = solve_ivp(fermentation, [t_start, t_end], y0, t_eval=t_eval)

# Eulers eksplisitte metode
def euler_explicit():
    s_values = [s0]
    x_values = [x0]
    for _ in range(n_steps):
        s, x = s_values[-1], x_values[-1]
        veksthastighet = umax * (s / (K + s)) * x
        ds = -veksthastighet * dt
        dx = yx * veksthastighet * dt
        s_values.append(s + ds)
        x_values.append(x + dx)
    return np.array(s_values), np.array(x_values)

# Midtpunktsmetoden
def midpoint_method():
    s_values = [s0]
    x_values = [x0]
    for _ in range(n_steps):
        s, x = s_values[-1], x_values[-1]
        veksthastighet = umax * (s / (K + s)) * x
        s_mid = s + (-veksthastighet * dt / 2)
        x_mid = x + (yx * veksthastighet * dt / 2)
        veksthastighet_mid = umax * (s_mid / (K + s_mid)) * x_mid
        ds = -veksthastighet_mid * dt
        dx = yx * veksthastighet_mid * dt
        s_values.append(s + ds)
        x_values.append(x + dx)
    return np.array(s_values), np.array(x_values)

# Løsninger
s_euler, x_euler = euler_explicit()
s_midpoint, x_midpoint = midpoint_method()
s_values_ivp = sol.y[0]
x_values_ivp = sol.y[1]
time_ivp = sol.t

# Plot
plt.figure(figsize=(12, 6))

# Sukkerkonsentrasjon
plt.plot(time_ivp / 24, s_values_ivp, label="Sukker (solve_ivp)", color="blue")
plt.plot(time / 24, s_euler, label="Sukker (Euler eksplisitt)", linestyle='--', color="cyan")
plt.plot(time / 24, s_midpoint, label="Sukker (Midtpunkt)", linestyle='-.', color="navy")

# Gjærkonsentrasjon
plt.plot(time_ivp / 24, x_values_ivp, label="Gjær (solve_ivp)", color="green")
plt.plot(time / 24, x_euler, label="Gjær (Euler eksplisitt)", linestyle='--', color="lime")
plt.plot(time / 24, x_midpoint, label="Gjær (Midtpunkt)", linestyle='-.', color="darkgreen")

# Merk og vis
plt.xlabel("Tid (dager)")
plt.ylabel("Konsentrasjon (g/L)")
plt.title("Fermentering: Sammenligning av numeriske metoder")
plt.grid()
plt.legend()
plt.tight_layout()
plt.show()
