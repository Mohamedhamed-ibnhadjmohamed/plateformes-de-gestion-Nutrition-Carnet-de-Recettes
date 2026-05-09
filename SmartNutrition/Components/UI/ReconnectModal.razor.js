export function showReconnectModal() {
    const modal = document.getElementById('reconnect-modal');
    if (modal) {
        modal.style.display = 'block';
    }
}

export function hideReconnectModal() {
    const modal = document.getElementById('reconnect-modal');
    if (modal) {
        modal.style.display = 'none';
    }
}
