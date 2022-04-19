import React, { useState, useEffect } from 'react';
import { PieChart } from 'react-minimal-pie-chart';
import './custom.css'

function App() {
  const [demographics, setDemographics] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5000/demographics").then(response =>
      response.json().then(data => {
        let dataobject = JSON.parse(data);
        setDemographics(dataobject);
      })
    );
  }, []);
  return (
    <div className="App">
      <PieChart
        data={[
          { title: 'M', value: demographics.MarriedPercentage, color: '#E38627' },
          { title: 'U', value: demographics.UnMarriedPercentage, color: '#C13C37' },
        ]}
        radius={30}
        label={({ dataEntry }) => dataEntry.title}
      />
    </div>
  );
 }
 
 export default App;
 