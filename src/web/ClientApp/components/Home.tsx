import * as React from 'react';
import 'isomorphic-fetch';
import { Line } from 'react-chartjs-2';

interface WeatherState {
    measurements: Measurement[];
    loading: boolean;
}

export class Home extends React.Component<any, WeatherState> {
    constructor() {
        super();
        this.state = { measurements: [], loading: true };

        fetch('/api/Weather/Latest')
            .then(response => response.json() as Promise<Measurement[]>)
            .then(data => {
                this.setState({ measurements: data, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderHome(this.state.measurements);

        return <div>
            <h1>Bulimba Weather</h1>
            {contents}
        </div>;
    }

    private static renderHome(measurements: Measurement[]) {
        return <div>
            {/* {Home.renderWeatherChart(measurements)} */}
            {Home.renderWeatherTable(measurements)}
        </div>
    }

    private static renderWeatherChart(measurements: Measurement[]) {
        const data = measurements.map(x => {return x.tempOut})
        return <Line data={data} width={600} height={250}/>
    }

    private static renderWeatherTable(forecasts: Measurement[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp in. (C)</th>
                    <th>Temp out. (C)</th>
                    <th>Wind Speed</th>
                    <th>Wind Direction</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(measurement =>
                    <tr key={measurement.time}>
                        <td> {measurement.time}</td>
                        <td>{measurement.tempIn}</td>
                        <td>{measurement.tempOut}</td>
                        <td>{measurement.windSpeed}</td>
                        <td>{measurement.windDirection}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Measurement {
    id: number;
    number: number;
    time: string;
    interval: number
    tempIn: number;
    humidityIn: number;
    tempOut: number;
    humidityOut: number;
    relativePressure: number;
    absolutePressure: number;
    windSpeed: number;
    gust: number;
    windDirection: string;
    dewPoint: number;
    windChill: number;
    hourlyRainfall: number;
}
