import React, { useState } from "react";
import "./IvfSuccessCalculator.css";

const IvfSuccessCalculator = () => {
  const [successRate, setSuccessRate] = useState(null);
  const [isMetricUnits, setIsMetricUnits] = useState(false);

  const [formData, setFormData] = useState({
    usingOwnEggs: false,
    previouslyAttemptedIVF: false,
    reasonForInfertilityKnown: false,
    age: "",
    feet: "",
    inches: "",
    heightInCm: "",
    weightInLbs: "",
    weightInKg: "",
    gravida: "",
    priorLiveBirths: "",
    tubalFactor: false,
    maleFactorInfertility: false,
    endometriosis: false,
    ovulatoryDisorder: false,
    diminishedOvarianReserve: false,
    uterineFactor: false,
    otherReason: false,
    unexplainedInfertility: false,
    usingMetric: isMetricUnits,
  });

  const convertLbsToKg = (lbs) => (parseFloat(lbs) || 0) * 0.453592;
  const convertKgToLbs = (kg) => (parseFloat(kg) || 0) * 2.20462;
  const convertFeetInchesToCm = (feet, inches) =>
    (parseFloat(feet) || 0) * 30.48 + (parseFloat(inches) || 0) * 2.54;
  const convertCmToFeetInches = (cm) => {
    const totalInches = (parseFloat(cm) || 0) / 2.54;
    const feet = Math.floor(totalInches / 12);
    let inches = totalInches % 12;

    inches = Math.round(inches * 100) / 100;
    return { feet, inches };
  };

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;

    setFormData((prevData) => {
      const updatedValue = type === "checkbox" ? checked : value;

      const updatedData = {
        ...prevData,
        [name]: updatedValue,
      };

      if (name === "weightInLbs" && !isMetricUnits) {
        updatedData.weightInKg =
          parseFloat(value) > 0 ? convertLbsToKg(value) : "";
      } else if (name === "weightInKg" && isMetricUnits) {
        updatedData.weightInLbs =
          parseFloat(value) > 0 ? convertKgToLbs(value) : "";
      } else if ((name === "feet" || name === "inches") && !isMetricUnits) {
        updatedData.heightInCm =
          updatedData.feet && updatedData.inches
            ? convertFeetInchesToCm(updatedData.feet, updatedData.inches)
            : "";
      } else if (name === "heightInCm" && isMetricUnits) {
        const { feet, inches } = convertCmToFeetInches(value);
        updatedData.feet = feet;
        updatedData.inches = inches;
      }

      return updatedData;
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const dataToSubmit = {
      ...formData,
      heightInCm: isMetricUnits
        ? formData.heightInCm
        : convertFeetInchesToCm(formData.feet, formData.inches),
      weightInKg: isMetricUnits
        ? formData.weightInKg
        : convertLbsToKg(formData.weightInLbs),
    };

    try {
      const response = await fetch(
        "http://localhost:5057/api/IVFSuccessCalculator",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(dataToSubmit),
        }
      );

      if (!response.ok) throw new Error(await response.text());
      setSuccessRate(await response.json());
    } catch (err) {
      console.error("Error occurred:", err);
    }
  };

  return (
    <div>
      <h1>IVF Success Calculator</h1>
      <form onSubmit={handleSubmit}>
        <div className="checkbox-group">
          {[
            {
              label: "Are you planning to use your own eggs?",
              name: "usingOwnEggs",
            },
            {
              label: "Have you attempted IVF in the past?",
              name: "previouslyAttemptedIVF",
            },
            {
              label: "Do you know the reason for your infertility?",
              name: "reasonForInfertilityKnown",
            },
          ].map(({ label, name }) => (
            <label key={name}>
              {label}
              <input
                type="checkbox"
                name={name}
                checked={formData[name]}
                onChange={handleChange}
              />
            </label>
          ))}
        </div>

        <div className="input-group">
          <label>Age:</label>
          <input
            type="number"
            name="age"
            value={formData.age}
            onChange={handleChange}
            required
            min="0"
          />
        </div>

        <div className="input-group">
          <label>Units:</label>
          <label className="switch">
            <input
              type="checkbox"
              checked={isMetricUnits}
              onChange={() => setIsMetricUnits(!isMetricUnits)}
            />
            <span className="slider"></span>
          </label>
          <span>{isMetricUnits ? "Metric" : "Imperial"}</span>
        </div>

        <div className="input-group">
          <label>Weight:</label>
          <div className="weight-inputs">
            {isMetricUnits ? (
              <div className="metric-inputs">
                <input
                  type="number"
                  name="weightInKg"
                  value={formData.weightInKg}
                  onChange={handleChange}
                  required
                  step="0.01"
                  min="0"
                />
                <span>kg</span>
              </div>
            ) : (
              <div className="imperial-inputs">
                <input
                  type="number"
                  name="weightInLbs"
                  value={formData.weightInLbs}
                  onChange={handleChange}
                  required
                  step="0.01"
                  min="0"
                />
                <span>lbs</span>
              </div>
            )}
          </div>
        </div>

        <div className="input-group">
          <label>Height:</label>
          <div className="height-inputs">
            {isMetricUnits ? (
              <div className="metric-inputs">
                <input
                  type="number"
                  name="heightInCm"
                  value={formData.heightInCm}
                  onChange={handleChange}
                  required
                  step="0.01"
                  min="0"
                />
                <span>cm</span>
              </div>
            ) : (
              <div className="imperial-inputs">
                <input
                  type="number"
                  name="feet"
                  value={formData.feet}
                  onChange={handleChange}
                  required
                  min="0"
                />
                <span>ft</span>
                <input
                  type="number"
                  name="inches"
                  value={
                    formData.inches === ""
                      ? ""
                      : formData.inches % 1 === 0
                      ? Number(formData.inches).toFixed(0)
                      : Number(formData.inches).toFixed(2)
                  }
                  onChange={handleChange}
                  required
                  step="0.01"
                  min="0"
                />
                <span>in</span>
              </div>
            )}
          </div>
        </div>

        <div className="checkbox-group">
          {[
            { label: "Tubal Factor", name: "tubalFactor" },
            { label: "Male Factor Infertility", name: "maleFactorInfertility" },
            { label: "Endometriosis", name: "endometriosis" },
            { label: "Ovulatory Disorder", name: "ovulatoryDisorder" },
            {
              label: "Diminished Ovarian Reserve",
              name: "diminishedOvarianReserve",
            },
            { label: "Uterine Factor", name: "uterineFactor" },
            { label: "Other", name: "otherReason" },
            {
              label: "Unknown (I have not seen a medical professional)",
              name: "unknownReason",
            },
          ].map(({ label, name }) => (
            <label key={name}>
              {label}
              <input
                type="checkbox"
                name={name}
                checked={formData[name]}
                onChange={handleChange}
              />
            </label>
          ))}
        </div>
        {[
          {
            label: "Number of Prior Pregnancies:",
            name: "gravida",
            type: "number",
          },
          {
            label: "Number of Live Births:",
            name: "priorLiveBirths",
            type: "number",
          },
        ].map(({ label, name, type }) => (
          <div key={name} className="input-group">
            <label>{label}</label>
            <input
              type={type}
              name={name}
              value={formData[name]}
              onChange={handleChange}
              required
              min="0"
            />
          </div>
        ))}
        <div className="calculate-container">
          <button type="submit">Calculate</button>
          {successRate && (
            <h3 className="success-rate">Chances of Sucess: {successRate}%</h3>
          )}
        </div>
      </form>
    </div>
  );
};

export default IvfSuccessCalculator;
