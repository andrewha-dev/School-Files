package b31_l04_testing;

/**
 * A class representing a temperature measured in Fahrenheit and Celsius.
 */
public class Temperature
{
  /**
   * The scale the temperature is measured in. Valid values are:
   * <ul> <li>'C' for Celsius
   * <li>'F' for Fahrenheit</ul>
   */
  private char units;

  /**
   * The temperature measured on the scale specified by units.
   */
  private double temperature;

  /**
   * Construct a default Temperature object. The units default to Celsius and the temperature is 0.
   */
  public Temperature()
  {
    units = 'C';
    temperature = 0.0;
  } // Temperature()

  /**
   * Construct a Temperature object using the arguments.
   * If the units are not valid, an illegal argument exception is thrown.
   * @param temp the temperature measured in the scale specified by units
   * @param type the temperature scale. Valid values are:
   * <ul> <li>'C' for Celsius
   * <li>'F' for Fahrenheit </ul>
   * @throws IllegalArgumentException if the type is not 'C' or 'F'
   */
  public Temperature(double temp, char type)
  {
    setUnits(type);
    setTemperature(temp);
  } // Temperature(double, char )

  /**
   * Get the Fahrenheit temperature for the object.
   * @return the temperature measured in Fahrenheit
   */
  public double getFahrenheit()
  {
    if (units == 'F')
 
      return temperature;
    else
      return (temperature * 1.8) + 32;
  } // getFahrenheit()

  /**
   * Get the Celsius temperature for the object.
   * @return the temperature measured in Celsius   */
  public double getCelsius()
  {
    if (units == 'C')
      return temperature;
    else
      return (temperature - 32) /1.8;
  } // getCelsius()

  /**
   * Get the units that the temperature is measured in.
   * @return 'C' or 'F' for Celsius or Fahrenheit temperatures
   */
  public char getUnits()
  {
    return units;
  } // getUnits()

  /**
   * Get the current temperature.
   * @return the temperature measured on the scale specified by units
   */
  public double getTemperature()
  {
    return temperature;
  } // getTemperature()

  /**
   * Set the current scale for the temperature.
   * If the units are not valid, an illegal argument exception is thrown.
   * @param type the temperature scale. Valid values are:
   * <ul> <li>'C' for Celsius
   * <li>'F' for Fahrenheit </ul>
   * @throws IllegalArgumentException if the type is not 'C', 'F' or 'K'
   */
  public void setUnits(char type)
  {
    type = Character.toUpperCase(type);
    if (type != 'F' && type != 'C' && type != 'K')
    	throw new IllegalArgumentException();
    this.units = type;
  } // setUnits()

  /**
   * Set the temperature in the scale specified by the units
   * @param temp the temperature measured in the scale specified by units
   */
  public void setTemperature(double temp)
  {
    this.temperature = temp;
  } // setTemperature()
} // Temperature
