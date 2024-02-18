import { useEffect, useState } from 'react';
import './App.css';
import {DataTable} from "./ip-registry/data-table.tsx";
import {columns} from "./ip-registry/columns.tsx";
import {Api, IpRegistration} from "./api/api.ts";
import {AddIPRegistrationForm} from "./ip-registry/add-registration.tsx";

function App() {
    const [ipRegistry, setIpRegistry] = useState<IpRegistration[]>([]);

    useEffect(() => {
        populateIpRegistry();
    }, []);
    
    const onNewRegistration = (ipRegistration: IpRegistration) => {
        console.info("IP Registration added:", ipRegistration)
        populateIpRegistry();
    }

    return (
        <div className="hidden h-full flex-1 flex-col space-y-8 p-8 md:flex">
            <div className="flex items-center justify-between space-y-2">
                <div>
                    <h2 className="text-2xl font-bold tracking-tight text-left">IP Registry</h2>
                    <p className="text-muted-foreground">
                        Here&apos;s a list of registered IPs
                    </p>
                </div>
                <div className="flex items-center space-x-2">
                    {/*<UserNav />*/}
                </div>
            </div>
            <AddIPRegistrationForm onSuccess={onNewRegistration}/>
            <DataTable data={ipRegistry} columns={columns}/>
        </div>
    );

    async function populateIpRegistry() {
        const client = new Api();
        const response = await client.ipRegistry.getIpRegistryList();
        setIpRegistry(response.data)
    }
}

export default App;