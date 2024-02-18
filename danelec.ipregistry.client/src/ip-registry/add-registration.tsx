"use client"

import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { z } from "zod"

import { Button } from "@/components/ui/button"
import {
    Form,
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import {Api, IpRegistration} from "../api/api.ts";

const formSchema = z.object({
    ip: z.string().ip(),
    name: z.string().min(2).max(50),
})

export function AddIPRegistrationForm({ onSuccess }: { onSuccess : (item: IpRegistration) => void}) {
    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            name: "",
        },
    })

    // 2. Define a submit handler.
    async function onSubmit(values: z.infer<typeof formSchema>) {
        // Do something with the form values.
        const client = new Api();
        const response = await client.ipRegistry.addIpRegistration(values);
        onSuccess(response.data);
    }
    
    return (
        <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className="flex justify-end align-middle">
                <FormField
                    control={form.control}
                    name="ip"
                    render={({ field }) => (
                        <FormItem>
                            {/*<FormLabel className="">IP</FormLabel>*/}
                            <FormControl>
                                <Input placeholder="192.168.0.1" {...field} />
                            </FormControl>
                            <FormMessage />
                        </FormItem>
                    )}
                />
                <FormField
                    control={form.control}
                    name="name"
                    render={({ field }) => (
                        <FormItem>
                            {/*<FormLabel>Name</FormLabel>*/}
                            <FormControl>
                                <Input placeholder="PC NAME 1" {...field} />
                            </FormControl>
                            <FormMessage />
                        </FormItem>
                    )}
                />
                <Button type="submit">Add</Button>
            </form>
        </Form>
    )
}