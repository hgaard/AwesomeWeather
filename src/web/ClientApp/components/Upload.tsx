import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Dropzone from 'react-dropzone'

interface DropState {
    files: File[];
}

export class Upload extends React.Component<RouteComponentProps<{}>, DropState> {
    constructor() {
        super();
        this.state = { files: []};
    }
     
     public onDrop(files : File[]) {
        this.setState({files : files});
     }

     public uploadFiles(){
        var data = new FormData()
        this.state.files.forEach(file => {
            data.append(file.name, file)
        });
        fetch('/api/Weather/upload', {
            method: 'POST',
            body: data
        })
     }
    public render() {
        return <div>
            <h1>Awesome weather upload!</h1>
            <p>Drop some csv files here to upload</p>
            <section>
                <div className="dropzone">
                    <Dropzone accept=".csv"  onDrop={this.onDrop.bind(this)}>
                        <p>Try dropping some files here, or click to select files to upload.</p>
                    </Dropzone>
                    </div>
                    <aside>
                        <h2>Dropped files</h2>
                            <ul>
                                {
                                    this.state.files.map(f => <li key={f.name}>{f.name} - {f.size} bytes</li>)
                                }
                            </ul>
                        <button onClick={() =>{this.uploadFiles()}}>Upload</button>
                    </aside>
            </section>
        </div>;
    }
}
