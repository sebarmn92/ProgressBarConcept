

const CallWithProgress = async (url = '', cbk = () => { }, headerOpt = {
    method: 'GET'
}) => {

    const response = await fetch(url, headerOpt);

    if (!response.ok) {
        console.error('Fetch failed:', response.status);
        return Promise.reject(response);
    }

    const reader = response.body.getReader();
    const decoder = new TextDecoder();

    while (true) {
        const { done, value } = await reader.read();
        if (done) break;
        const chunk = decoder.decode(value, { stream: true });
        const respData = {
                        streamed_data: JSON.parse(chunk),
                        response
        }                       
        cbk(respData)
    }
}

export default CallWithProgress;