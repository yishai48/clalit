import React from 'react';
import { useState, useEffect,Link } from "react"
import './Home.css'
//Bitcoin Api
function Home() {
  const [coins, setCoins] = useState([])


    useEffect(() => {
      fetch('https://localhost:44354/api/WeatherForecast/GetCoins')
         .then((res) => res.json())
      
         .then((data) => {
            console.log(data);
            setCoins(data);
         })
         .catch((err) => {
            console.log(err.message);
         });
   }, []);

  return (
       <section className="coins">
      <table className='table table-hover'>
        <thead>
          <tr>
            <th>CurrentChange</th>
            <th>CurrentExchangeRate</th>
            <th>Key</th>
            <th>LastUpdate</th>
            <th>Unit</th>
          </tr>
        </thead>

        <tbody>
          {coins.map(({ CurrentChange, CurrentExchangeRate, Key, LastUpdate,Unit   }) => (CurrentChange<0?console.log(CurrentChange):
            <tr key={CurrentChange}>
            <td>{CurrentChange}</td>
            <td>{CurrentExchangeRate}</td>
              <td>{Key}</td>
              <td>{LastUpdate}</td>
              <td>{Unit}</td>
            </tr>
          ))}
        </tbody>
      </table>

    </section>
  );
}

export default Home;
